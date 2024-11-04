using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class FgsaleEdiOrderList
    {
        public string OrderListPoNo { get; set; } = null!;
        public string OrderListItemNo { get; set; } = null!;
        public string OrderListSplitItemNo { get; set; } = null!;
        public string? OrderListPoList { get; set; }
        public string? OrderListDrawingDci { get; set; }
        public string? OrderListDrawingCustomer { get; set; }
        public string? OrderListPlType { get; set; }
        public string? OrderListCm { get; set; }
        public string? OrderListDescription { get; set; }
        public int? OrderListQtyBox { get; set; }
        public DateTime? OrderListDelDueTime { get; set; }
        public string? OrderListWhno { get; set; }
        public string? OrderListDel { get; set; }
        public decimal? OrderListWhqty { get; set; }
        public string? OrderListWu { get; set; }
        public decimal? OrderListIvqty { get; set; }
        public string? OrderListIu { get; set; }
        public string? OrderListPt { get; set; }
        public decimal? OrderListPrice { get; set; }
        public decimal? OrderListTotal { get; set; }
        public DateTime? OrderListStartLoad { get; set; }
        public DateTime? OrderListEndLoad { get; set; }
        public DateTime? OrderListEtd { get; set; }
        public DateTime? OrderListEta { get; set; }
        public DateTime? OrderListLtd { get; set; }
    }
}
