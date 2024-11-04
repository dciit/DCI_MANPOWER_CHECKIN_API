using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViEinvoiceSupInvoice
    {
        public int RndId { get; set; }
        public int InvId { get; set; }
        public int DryId { get; set; }
        public string? RndInvno { get; set; }
        public string RndInvnoSup { get; set; } = null!;
    }
}
