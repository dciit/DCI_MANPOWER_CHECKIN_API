namespace API_DCI_DIAGRAM_SVG.Models
{
    public class ParamsWIPInfo
    {

    }

    public class ParamsWIpAdjustInfo
    {
        public string ymd { get; set; }
        public string wcno { get; set; }
        public string partno { get; set; }
        public string cm { get; set; }
        public decimal adj_qty { get; set; }
        public string adj_by { get; set; }
        public string? remark { get; set; } = "";
        public decimal? wipBefore { get; set; } = 0;
    }


}
