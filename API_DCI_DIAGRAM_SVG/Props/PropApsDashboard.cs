namespace API_DCI_DIAGRAM_SVG.Props
{
    public class PropApsDashboard
    {
        public PropInProcess inprocess { get; set; } = new PropInProcess();
        public List<PropMainSequence> mainSequence { get; set; } = new List<PropMainSequence>();
    }

    public class PropMainSequence
    {
        public string prdSeq { get; set; } = "";
        public string sebango { get; set; } = "";
        public string model { get; set; } = "";
        public decimal plan { get; set; } = 0;
        public decimal result { get; set; } = 0;
        public decimal remain {  get; set; } = 0;
        public List<PropMainHeader> mainHeaders { get; set; } = new List<PropMainHeader>();
        public List<PropMainData> mainDatas { get; set; } = new List<PropMainData>();
        
    }
    public class PropMainData
    {
        public string processName { get; set; } = ""; // MAIN OR SUBLINE
        public string processGroup { get; set; } = ""; // CS, HS, LW ....
        public decimal qty { get; set; } = 0;
    }

    public class PropMainHeader
    {
        public string text { get; set; } = "";
        public string value { get; set; } = "";
    }

  

    public class PropInProcess
    {
        public string prdSeq { get; set; } = "";
        public string sebango { get; set; } = "";
        public int percent { get; set; } = 0;
        public decimal plan { get; set; } = 0;
        public decimal resullt {  get; set; } = 0;
        public decimal diff { get; set; } = 0;
    }
}
