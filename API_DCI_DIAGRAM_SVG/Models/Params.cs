namespace API_DCI_DIAGRAM_SVG.Models
{
    public class Params
    {

    }

    public class ParamGetStockSubline
    {
        public string ymd { get; set; }
        public string? modelName { get; set; }
    }
    public class ParamStringInt
    {
        public string modelCode { get; set; }
        public int result { get; set; } = 0;
    }
}