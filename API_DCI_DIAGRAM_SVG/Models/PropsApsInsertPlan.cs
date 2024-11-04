namespace API_DCI_DIAGRAM_SVG.Models
{
    public class PropsApsInsertPlan
    {
        //public string model { get; set; }
        //public string partNo { get; set; }
        //public string wcno { get; set; }
        //public int prdQty { get; set; } = 0;
        //public string planDate { get; set; }
        //public string partGroup { get; set; }
        //public string empcode { get; set; }
        //public int prdSeq { get; set; } = 0;
        //public string partGroupName {  get; set; }  
        public string date { get; set; }
        public string model { get; set; }
        public decimal qty { get; set; } = 0;
        public string empcode { get;set; }
        public string wcno {  get; set; }
        public int? seq { get; set; } = 0;
        public string type { get; set; } // MAIN OR SUBLINE
        public string? partGroup { get;set; }
    }
}
