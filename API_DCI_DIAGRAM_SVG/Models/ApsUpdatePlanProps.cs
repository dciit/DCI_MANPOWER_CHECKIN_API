namespace API_DCI_DIAGRAM_SVG.Models
{
    public class ApsUpdatePlanProps
    {
        public string prdPlanCode {  get; set; }
        public string reasonCode { get;set; }
        public int prdPlanQty { get; set; } = 0;
        public string remark { get; set; }
    }
}
