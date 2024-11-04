namespace API_DCI_DIAGRAM_SVG.Models
{
    public class ApsInsertPlanProps
    {
        public string modelCode { get; set; }
        public int prdQty { get; set; }
        public string prdPlanCode { get;set; }
        public string? empcode { get; set; } = "";
    }
}
