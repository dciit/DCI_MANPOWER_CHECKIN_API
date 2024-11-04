using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ItemReceiptTransactionPackageType
    {
        public string EinvoiceId { get; set; } = null!;
        public string Invoice { get; set; } = null!;
        public string PoNbr { get; set; } = null!;
        public string PartId { get; set; } = null!;
        public bool DataVendor { get; set; }
        public bool PackageComplete { get; set; }
        public string LotType { get; set; } = null!;
    }
}
