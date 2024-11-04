using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class SupplierDeliveryTime
    {
        public string SupplierNo { get; set; } = null!;
        public string SupplierDelivery { get; set; } = null!;
        public string? SupplierEmail { get; set; }
        /// <summary>
        /// Can generate barcode before create einvoice. (Thai UI, Magnet Wire)
        /// </summary>
        public bool? IsSemiAuto { get; set; }
    }
}
