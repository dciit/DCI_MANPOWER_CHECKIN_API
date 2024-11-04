using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoSupplierInvoice
    {
        public long IdentId { get; set; }
        public int RndId { get; set; }
        public string RndInvnoSup { get; set; } = null!;
        public DateTime RndInvnoSupDate { get; set; }
        public int DpId { get; set; }
        public decimal InvQty { get; set; }
    }
}
