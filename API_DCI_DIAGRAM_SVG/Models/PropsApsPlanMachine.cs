namespace API_DCI_DIAGRAM_SVG.Models
{
    public class PropsApsPlanMachine
    {
        public string prdPlanCode { get; set; }  
        public string wcno { get;set; }
        public int apsSeq {  get;set; }
        public string apsPlanDate { get;set; }
        public int prdSeq { get;set; }
        public string partNo { get;set; }
        public string cm { get;set; }
        public int apsPlanQty { get; set; } = 0;
        public int prdPlanQty { get; set;} = 0;
        public int lrev { get; set; } = 0;
        public string partGroup {  get; set; }
        public decimal stockMain {  get; set; } 
        public decimal? stockMachine { get; set; }
        public decimal result { get; set; } = 0;
        public string? reason { get; set; }
        public string? remark { get; set; }
        public string? subLine { get; set; } = "";
    }
}
