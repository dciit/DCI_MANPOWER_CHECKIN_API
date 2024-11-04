namespace API_DCI_DIAGRAM_SVG.Models
{
    public class PropPriorityPlan
    {
        public string date { get; set; }
        public string wcno { get; set; }
        public string subLine { get; set; }
        public string model { get; set; }
        public string modelCode {  get; set; }
        public int plan { get; set; } = 0;
        public string packing {  get; set; }
        public int palletQty { get; set; }
        public string remark {  get; set; }
    }
}
