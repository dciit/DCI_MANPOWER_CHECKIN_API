using API_DCI_DIAGRAM_SVG.Contexts;
using API_DCI_DIAGRAM_SVG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace API_DCI_DIAGRAM_SVG
{
    public class Service
    {
        private readonly DBDCI _contextDCI;
        private readonly ManpowerContext _contxMP;
        private readonly HRMContext _contxHRM;
        private readonly DBSCM _contxSCM;
        public Service(DBDCI contextDCI, ManpowerContext contxMP, HRMContext contxHRM, DBSCM contxSCM)
        {
            _contextDCI = contextDCI;
            _contxMP = contxMP;
            _contxHRM = contxHRM;
            _contxSCM = contxSCM;
        }

        public Service()
        {
        }

        public string getCounter(string objCode)
        {
            int CounterManSkill = 0;
            List<MpckDictionary> oMQs = _contxMP.MpckDictionaries.Where(d => d.DictRefCode == objCode && d.DictType == "MQ").ToList();
            int MQLength = oMQs.Count;
            List<string> MQGroupMQNo = oMQs.Select(x => x.DictCode).Distinct().ToList();
            List<ViTrTrainessLog> AAA = _contextDCI.ViTrTrainessLog.Where(x => MQGroupMQNo.Contains(x.MqNo) && x.Status == "post" && x.Result == "P").Select(x => new ViTrTrainessLog
            {
                EmpCode = x.EmpCode,
                MqNo = x.MqNo
            }).ToList().GroupBy(x => x.EmpCode).Select(y => new ViTrTrainessLog { EmpCode = y.Key, Score = y.GroupBy(x => x.MqNo).Count() }).Where(z => z.Score == MQLength).ToList();

            List<MpckDictionary> oSAs = _contxMP.MpckDictionaries.Where(d => d.DictRefCode == objCode && d.DictType == "SA").ToList();
            if (oSAs != null)
            {
                int SALength = oSAs.Count;
                List<string> SAGroupSA = oSAs.Select(x => x.DictCode).Distinct().ToList();
                var BBB = _contxSCM.SkcLicenseTrainings
                .Where(x => SAGroupSA.Contains(x.DictCode!)).Select(x => new SkcLicenseTraining
                {
                    DictCode = x.DictCode,
                    Empcode = x.Empcode
                }).ToList().GroupBy(x => x.Empcode).Select(y => new
                {
                    Empcode = y.Key,
                    Count = y.GroupBy(x => x.DictCode).Count()
                }).Where(x => x.Count == SALength).Select(z => z.Empcode).ToList();
                var CCC = AAA.Select(x => x.EmpCode).Intersect(BBB).Distinct().ToList();
                CounterManSkill = CCC.Count();
            }
            return CounterManSkill.ToString("D2");
        }

    }
}
