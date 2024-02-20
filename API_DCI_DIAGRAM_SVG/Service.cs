using API_DCI_DIAGRAM_SVG.Contexts;
using API_DCI_DIAGRAM_SVG.Models;

namespace API_DCI_DIAGRAM_SVG
{
    public class Service
    {
        private readonly DBDCI _contextDCI;
        private readonly ManpowerContext _contxMP;
        private readonly HRMContext _contxHRM;
        public Service(DBDCI contextDCI, ManpowerContext contxMP, HRMContext contxHRM)
        {
            _contextDCI = contextDCI;
            _contxMP = contxMP;
            _contxHRM = contxHRM;
        }

        public MModels.MManSkill getCounter(string objCode)
        {
            int CounterManSkill = 0;
            List<Employee> ListEmpCodeOfSkill = new List<Employee>();
            List<MpckDictionary> oMQs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == objCode && d.DictType == "MQ").ToList();
            int MQLength = oMQs.Count;
            List<string> MQGroupMQNo = oMQs.Select(x => x.DictCode).Distinct().ToList();
            List<ViTrTrainessLog> AAA = _contextDCI.ViTrTrainessLog.Where(x => MQGroupMQNo.Contains(x.MqNo) && x.Status == "post" && x.Result == "P").Select(x => new ViTrTrainessLog
            {
                EmpCode = x.EmpCode,
                MqNo = x.MqNo
            }).ToList().GroupBy(x => x.EmpCode).Select(y => new ViTrTrainessLog { EmpCode = y.Key, Score = y.GroupBy(x => x.MqNo).Count() }).Where(z => z.Score == MQLength).ToList();

            List<MpckDictionary> oSAs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == objCode && d.DictType == "SA").ToList();
            if (oSAs != null)
            {
                int SALength = oSAs.Count;
                List<string> SAGroupSA = oSAs.Select(x => x.DictCode).Distinct().ToList();
                var BBB = _contxMP.SkcLicenseTraining
                .Where(x => SAGroupSA.Contains(x.DictCode!)).Select(x => new SkcLicenseTraining
                {
                    DictCode = x.DictCode,
                    Empcode = x.Empcode
                }).ToList().GroupBy(x => x.Empcode).Select(y => new
                {
                    Empcode = y.Key,
                    Count = y.GroupBy(x => x.DictCode).Count()
                }).Where(x => x.Count == SALength).Select(z => z.Empcode).ToList();


                if (AAA.Count > 0 && BBB.Count > 0)
                {
                    var B = AAA.Select(x => x.EmpCode).Intersect(BBB).Distinct().ToList();
                    ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => B.Contains(x.Code)).ToList();
                    CounterManSkill = B.Count();
                }
                else if (AAA.Count > 0 && BBB.Count  == 0)
                {
                        var A = AAA.Select(x => x.EmpCode).Distinct().ToList();
                        ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => A.Contains(x.Code)).ToList();
                        CounterManSkill = A.Count();
                    //else
                    //{
                    //    var A = BBB.Select(x => x).Distinct().ToList();
                    //    ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => A.Contains(x.Code)).ToList();
                    //    CounterManSkill = A.Count();
                    //}
                }
                else if (AAA.Count == 0 && BBB.Count > 0)
                {
                    var A = BBB.Select(x => x).Distinct().ToList();
                    ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => A.Contains(x.Code)).ToList();
                    CounterManSkill = A.Count();
                }
                else
                {
                    CounterManSkill = 0;
                }

            }
            if (oMQs.Count == 0 && oSAs.Count == 0)
            {
                CounterManSkill = 0;
            }
            return new MModels.MManSkill
            {
                counter = CounterManSkill.ToString("D2"),
                employees = ListEmpCodeOfSkill
            };
        }


        public MModels.MManSkill GetEmployeeListInMQSA(string objCode)
        {
            int CounterManSkill = 0;
            List<Employee> ListEmpCodeOfSkill = new List<Employee>();
            List<MpckDictionary> oMQs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == objCode && d.DictType == "MQ").ToList();
            int MQLength = oMQs.Count;
            List<string> MQGroupMQNo = oMQs.Select(x => x.DictCode).Distinct().ToList();
            List<ViTrTrainessLog> oEmpMQs = _contextDCI.ViTrTrainessLog.Where(x => MQGroupMQNo.Contains(x.MqNo) && x.Status == "post" && x.Result == "P").Select(x => new ViTrTrainessLog
            {
                EmpCode = x.EmpCode,
                MqNo = x.MqNo
            }).ToList().GroupBy(x => x.EmpCode).Select(y => new ViTrTrainessLog { EmpCode = y.Key, Score = y.GroupBy(x => x.MqNo).Count() }).Where(z => z.Score == MQLength).ToList();

            List<MpckDictionary> oSAs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == objCode && d.DictType == "SA").ToList();
            oSAs = (from a in oSAs
                    join b in _contxMP.SkcDictMstr.Where(x => x.DictStatus == true)
                    on a.DictCode equals b.Code
                    where b.DictStatus == true
                    select a
                    ).ToList();

            if (oMQs.Count > 0 && oSAs.Count > 0)
            {
                int SALength = oSAs.Count;
                List<string> SAGroupSA = oSAs.Select(x => x.DictCode).Distinct().ToList();
                var oEmpSAs = _contxMP.SkcLicenseTraining
                .Where(x => SAGroupSA.Contains(x.DictCode!)).Select(x => new SkcLicenseTraining
                {
                    DictCode = x.DictCode,
                    Empcode = x.Empcode
                }).ToList().GroupBy(x => x.Empcode).Select(y => new
                {
                    Empcode = y.Key,
                    Count = y.GroupBy(x => x.DictCode).Count()
                }).Where(x => x.Count == SALength).Select(z => z.Empcode).ToList();
                var IntersectEmp = oEmpMQs.Select(x => x.EmpCode).Intersect(oEmpSAs).Distinct().ToList();
                ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => IntersectEmp.Contains(x.Code) && x.Resign.ToString() == "1900-01-01").ToList();
                CounterManSkill = IntersectEmp.Count();
            }
            else if (oMQs.Count > 0 && oSAs.Count == 0)
            {
                var oGroupEmpMQ = oEmpMQs.Select(x => x.EmpCode).Distinct().ToList();
                ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => oGroupEmpMQ.Contains(x.Code)).ToList();
                CounterManSkill = oGroupEmpMQ.Count();
            }
            else if (oSAs.Count > 0 && oMQs.Count == 0)
            {
                int SALength = oSAs.Count;
                List<string> SAGroupSA = oSAs.Select(x => x.DictCode).Distinct().ToList();
                var oEmpSAs = _contxMP.SkcLicenseTraining
                .Where(x => SAGroupSA.Contains(x.DictCode!)).Select(x => new SkcLicenseTraining
                {
                    DictCode = x.DictCode,
                    Empcode = x.Empcode
                }).ToList().GroupBy(x => x.Empcode).Select(y => new
                {
                    Empcode = y.Key,
                    Count = y.GroupBy(x => x.DictCode).Count()
                }).Where(x => x.Count == SALength).Select(z => z.Empcode).ToList();
                var IntersectEmp = oEmpSAs.Distinct().ToList();
                ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => IntersectEmp.Contains(x.Code) && x.Resign.ToString() == "1900-01-01").ToList();
                CounterManSkill = IntersectEmp.Count();
            }
            else
            {

            }


            //if (oSAs.Count == 0)
            //{
            //    var A = oEmpMQs.Select(x => x.EmpCode).Distinct().ToList();
            //    ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => A.Contains(x.Code)).ToList();
            //    CounterManSkill = A.Count();
            //}
            //else
            //{
            //    int SALength = oSAs.Count;
            //    List<string> SAGroupSA = oSAs.Select(x => x.DictCode).Distinct().ToList();
            //    var oEmpSAs = _contxMP.SkcLicenseTraining
            //    .Where(x => SAGroupSA.Contains(x.DictCode!)).Select(x => new SkcLicenseTraining
            //    {
            //        DictCode = x.DictCode,
            //        Empcode = x.Empcode
            //    }).ToList().GroupBy(x => x.Empcode).Select(y => new
            //    {
            //        Empcode = y.Key,
            //        Count = y.GroupBy(x => x.DictCode).Count()
            //    }).Where(x => x.Count == SALength).Select(z => z.Empcode).ToList();

            //    if (oMQs.Count > 0 && oSAs.Count > 0)
            //    {
            //        var IntersectEmp = oEmpMQs.Select(x => x.EmpCode).Intersect(oEmpSAs).Distinct().ToList();
            //        ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => IntersectEmp.Contains(x.Code) && x.Resign.ToString() == "1900-01-01").ToList();
            //        CounterManSkill = IntersectEmp.Count();
            //    }

            //}

            return new MModels.MManSkill
            {
                counter = CounterManSkill.ToString("D2"),
                employees = ListEmpCodeOfSkill
            };
        }


        public List<MpckDictionary> getMQofObj(string objCode)
        {

            List<MpckDictionary> list = new List<MpckDictionary>();
            list = _contxMP.MpckDictionary.Where(x => x.DictRefCode == objCode && x.DictType == "MQ").ToList();
            return list;
        }


        public List<SkcDictMstr> getSAofObj(string objCode)
        {
            List<SkcDictMstr> list = new List<SkcDictMstr>();
            List<MpckDictionary> oSAs = _contxMP.MpckDictionary.Where(d => d.DictRefCode == objCode && d.DictType == "SA").ToList();
            if (oSAs.Count > 0)
            {
                List<SkcDictMstr> oSAALLs = _contxMP.SkcDictMstr.Where(d => d.Code == d.RefCode && d.DictStatus == true && d.DictType == "LICENSE").ToList();
                list = (from sa in oSAs.OrderBy(b => b.DictCode)
                        join saall in oSAALLs
                        on sa.DictCode equals saall.Code
                        select new SkcDictMstr()
                        {
                            Code = sa.DictCode,
                            DictDesc = saall.DictDesc
                        }).ToList();
            }

            return list;
        }
    }
}
