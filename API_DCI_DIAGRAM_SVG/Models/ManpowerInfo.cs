namespace API_DCI_DIAGRAM_SVG.Models
{
    public class ManpowerInfo
    {
        public DateTime dataDate { set; get; }
        public string dataShift { set; get; }
        public string lineNo { set; get; }
        public string lineType { set; get; }
        public string lineSubCode { set; get; }
        public string lineSubName { set; get; }
        public string DVCD { set; get; }
        public string mpPDPlan { set; get; }
        public string mpStandard { set; get; }
        public string mpRegis { set; get; }
        public List<empCodeInfo> mpRegisLists { set; get; } = new List<empCodeInfo>();
        public string mpActual { set; get; }
        public List<empCodeInfo> mpActualLists { set; get; } = new List<empCodeInfo>();
        public string mpDiff { set; get; }
        public string mpAbsent { set; get; }
        public List<empCodeInfo> mpAbsentLists { set; get; } = new List<empCodeInfo>();
        public string mpSupportOut { set; get; }
        public List<empCodeInfo> mpSupportOutLists { set; get; } = new List<empCodeInfo>();
        public string mpSupportIn { set; get; }
        public List<empCodeInfo> mpSupportInLists { set; get; } = new List<empCodeInfo>();
        public string mpAnnual { set; get; }
        public List<empCodeInfo> mpAnnualLists { set; get; } = new List<empCodeInfo>();
        public string attWork { set; get; }
        public List<empCodeInfo> attWorkLists { set; get; } = new List<empCodeInfo>();
        public string attOT { set; get; }
        public List<empCodeInfo> attOTLists { set; get; } = new List<empCodeInfo>();
        public string attCheckIn { set; get; }
        public List<empCodeInfo> attCheckInLists { set; get; } = new List<empCodeInfo>();
        public string attNoLicense { set; get; }
        public List<empCodeInfo> attNoLicenseLists { set; get; } = new List<empCodeInfo>();
        public string attNoSkill { set; get; }
        public List<empCodeInfo> attNoSkillLists { set; get; } = new List<empCodeInfo>();
        public string attNoSA { set; get; }
        public List<empCodeInfo> attNoSALists { set; get; } = new List<empCodeInfo>();
        public string attNoMQ { set; get; }
        public List<empCodeInfo> attNoMQLists { set; get; } = new List<empCodeInfo>();
        public string attNoCheckIn { set; get; }
        public List<empCodeInfo> attNoCheckInLists { set; get; } = new List<empCodeInfo>();
    }

    public class LineTitleInfo
    {
        public string lineNo { set; get; }
        public string lineTitle { set; get; }
        public string lineType { set; get; }
        public string lineSubCode { set; get; }
        public string lineSubName { set; get; }
        public string DVCD { set; get; }
        public string SortOrder { set; get; }
    }


    public class EmpInfo
    {
        public string Code { set; get; }
        public string Name { set; get; }
        public string Surn { set; get; }
        public string FName { set; get; }
        public string Posit { set; get; }
        public string Dvcd { set; get; }
        public string LineCode { set; get; }
        public string OTStatus { set; get; }        
    }



    public class empCodeInfo
    {
        public string empCode { set; get; }
    }

    public class paramLineInfo
    {
        public string lineNo { set; get; }
    }

    public class paramDateShiftInfo
    {
        public DateTime paramDate { set; get; }
        public string paramShift { set; get; }
    }



    public class paramDateWCNOInfo
    {
        public string paramDate { set; get; }
        public string paramWCNO { set; get; }
    }

    public class paramAuthenInfo
    {
        public string userName { set; get; }
        public string passWord { set; get; }
    }


}
