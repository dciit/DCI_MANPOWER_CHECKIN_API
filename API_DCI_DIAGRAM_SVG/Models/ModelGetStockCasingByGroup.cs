namespace API_DCI_DIAGRAM_SVG.Models
{
    public class ModelGetStockCasingByGroup
    {
        public int PrdSeq { get; set; } = 0;
        public string Model { get; set; } = "";
        public string ModelName { get; set; } = "";
        public string PartNo { get; set; } = "";
        public string Cm { get; set; } = "";
        public int RemainPlan { get; set; } = 0;
        public string RawMaterial { get; set; } = "";
        public string Time { get; set; } = "";
        public decimal ResultMain { get; set; } = 0;

        public decimal ResultSubline { get; set; } = 0;
        public Dictionary<string, decimal> Data { get; set; } = new Dictionary<string, decimal>();

    }
}
