namespace API_DCI_DIAGRAM_SVG.Models
{
    public class FGWIPInfo
    {
        public string WCNO { set; get; }
        public string ModelCode { set; get; }
        public string ModelName { set; get; }
        public int EstimateMainSet { set; get; } = 0;
        public string EstimateAllSet { set; get; }
        public DateTime dataDateTime { set; get; }

        public string StatorMain { set; get; }
        public string StatorSubLine { set; get; }
        public bool StatorSafety { set; get; }
        public List<NoticeInfo> StatorNotice { set; get; }

        public string RotorMain { set; get; }
        public string RotorSubLine { set; get; }
        public bool RotorSafety { set; get; }
        public List<NoticeInfo> RotorNotice { set; get; }

        public string FSMain { set; get; }
        public string FSSubLine { set; get; }
        public bool FSSafety { set; get; }
        public List<NoticeInfo> FSNotice { set; get; }

        public string HSMain { set; get; }
        public string HSSubLine { set; get; }
        public bool HSSafety { set; get; }
        public List<NoticeInfo> HSNotice { set; get; }

        public string CSMain { set; get; }
        public string CSSubLine { set; get; }
        public bool CSSafety { set; get; }
        public List<NoticeInfo> CSNotice { set; get; }

        public string LWMain { set; get; }
        public string LWSubLine { set; get; }
        public bool LWSafety { set; get; }
        public List<NoticeInfo> LWNotice { set; get; }

        public string CBMain { set; get; }
        public string CBSubLine { set; get; }
        public bool CBSafety { set; get; }
        public List<NoticeInfo> CbNotice { set; get; }

        public string BODYMain { set; get; }
        public string BODYSubLine { set; get; }
        public bool BODYSafety { set; get; }
        public List<NoticeInfo> BODYNotice { set; get; }

        public string TOPMain { set; get; }
        public string TOPSubLine { set; get; }
        public bool TOPSafety { set; get; }
        public List<NoticeInfo> TOPNotice { set; get; }

        public string BOTTOMMain { set; get; }
        public string BOTTOMSubLine { set; get; }
        public bool BOTTOMSafety { set; get; }
        public List<NoticeInfo> BOTTOMNotice { set; get; }

    }


    public class FGPlanInfo
    {
        public string PrdPlanCode { set; get; }
        public string WCNO { set; get; }
        public string SubLine { set; get; }
        public int APSSeq { set; get; }
        public DateTime APSPlanDate { set; get; }
        public int PrdSeq { set; get; }
        public string ModelCode {  set; get; }
        public string PartNo { set; get; }
        public string CM { set; get; }
        public int APSPlanQty { set; get; }
        public int PrdPlanQty { set; get; }
        public bool ChangePlanQty { get; set; } = false;
        public FGWIPInfo dataWIP { set; get; } = new FGWIPInfo();
        public string StatusPlan { set; get; } = "";
        public string ApsCurrent { set; get; } = "";

        public List<ApsProductionPlanNotice> notifys { get; set; } = new List<ApsProductionPlanNotice>();

    }

    public class NoticeInfo
    {
        public string Prd_PlanCode { set; get; }
        public string Ymd { set; get; }
        public string Sht { set; get; }
        public string Notices { set; get; }
        public string WCNO { set; get; }
        public string PartNo { set; get; }
        public string CM { set; get; }
        public string CreateBy { set; get; }
        public DateTime CreateDT { set; get; }
    }


    public class UserInfo
    {
        public string code { get; set; }
        public string name { get; set; }
        public string surn { get; set; }
        public string img { get; set; }
        public string fullName { get; set; }
    }


}
