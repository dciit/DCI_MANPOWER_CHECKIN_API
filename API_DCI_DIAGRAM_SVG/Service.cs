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

                if (AAA.Count > 0 || BBB.Count > 0)
                {
                    if (AAA.Count > 0)
                    {
                        var A = AAA.Select(x => x.EmpCode).Distinct().ToList();
                        ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => A.Contains(x.Code)).ToList();
                        CounterManSkill = A.Count();
                    }
                    else
                    {
                        var A = BBB.Select(x => x).Distinct().ToList();
                        ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => A.Contains(x.Code)).ToList();
                        CounterManSkill = A.Count();
                    }
                }
                else if (AAA.Count > 0 && BBB.Count > 0)
                {
                    var B = AAA.Select(x => x.EmpCode).Intersect(BBB).Distinct().ToList();
                    ListEmpCodeOfSkill = _contxHRM.Employee.Where(x => B.Contains(x.Code)).ToList();
                    CounterManSkill = B.Count();
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

    }
}
