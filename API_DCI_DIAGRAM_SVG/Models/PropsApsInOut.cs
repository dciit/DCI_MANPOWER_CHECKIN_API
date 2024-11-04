namespace API_DCI_DIAGRAM_SVG.Models
{
    public class PropsApsInOut
    {
        public string planDate { get; set; }
        public string wcno { get; set; }
        public string partno { get; set; }
        public string cm { get; set; }
        public decimal subLbal { get; set; } = 0;
        public decimal subRecQty { get; set; } = 0;
        public decimal subIssQty { get; set; } = 0;
        public decimal subBal { get; set; } = 0;

        public decimal mainLbal { get; set; } = 0;
        public decimal mainRecQty { get; set; } = 0;
        public decimal mainIssQty { get; set; } = 0;
        public decimal mainBal { get; set; } = 0;
    }
}
