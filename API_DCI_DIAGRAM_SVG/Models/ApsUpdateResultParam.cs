namespace API_DCI_DIAGRAM_SVG.Models
{
    public class ApsUpdateResultParam
    {
        public string ym { get; set; }
        public string ymd { get; set; }
        public string wcno { get; set; }
        public string partno { get; set; }

        public string cm { get; set; }
        public string shift { get; set; }
        public string type { get; set; }
        public decimal qty { get; set; } = 0;
        public string period { get; set; }
        public string createBy { get; set; }
    }
}
