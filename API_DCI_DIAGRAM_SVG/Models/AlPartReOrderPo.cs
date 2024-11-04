using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class AlPartReOrderPo
    {
        public string Weekdate { get; set; } = null!;
        public string Caldate { get; set; } = null!;
        public int Calno { get; set; }
        public string Dataset { get; set; } = null!;
        public string Prdym { get; set; } = null!;
        public string Wcno { get; set; } = null!;
        public string Partno { get; set; } = null!;
        public string Cm { get; set; } = null!;
        public string? Desc1 { get; set; }
        public string? Route { get; set; }
        public string Vendorcode { get; set; } = null!;
        public string? Vendorshort { get; set; }
        public string? Vendorname { get; set; }
        public int? OrderLt { get; set; }
        public string? Deldate { get; set; }
        public string? Delplace { get; set; }
        public string? Cnvcode { get; set; }
        public decimal? Cnvweight { get; set; }
        public string? Cnvum { get; set; }
        public decimal? Minqty { get; set; }
        public string? Boipj { get; set; }
        public decimal? Stdcost { get; set; }
        public string? Pricetype { get; set; }
        public decimal? Price { get; set; }
        public string? Currency { get; set; }
        public string? Remark { get; set; }
        public decimal? Qtybox { get; set; }
        public string? Whum { get; set; }
        public decimal? Ngqty { get; set; }
        public decimal? Costamt { get; set; }
        public decimal? Whorderqty { get; set; }
        public decimal? Ivorderqty { get; set; }
        public string? Ivum { get; set; }
        public decimal? Orderamt { get; set; }
        public decimal? Logicalqty { get; set; }
        public string? Calby { get; set; }
    }
}
