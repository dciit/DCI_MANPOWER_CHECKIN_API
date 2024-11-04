namespace DCI_MANPOWER_API.Params
{
    public class ParamUpdateLayoutDetail
    {
        public string layoutCode { get; set; } = "";
        public string layoutName { get; set; } = "";
        public int width { get; set; } = 1200;
        public int height { get; set; } = 500;
        public string bypassMQ { get; set; } = "FALSE";
        public string bypassSA { get; set; } = "FALSE";
        public string updateBy { get; set; } = "";
        public string layoutStatus { get; set; } = "INACTIVE";
    }
}
