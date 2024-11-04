using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoSupInvoice
    {
        public int InvId { get; set; }
        public int RndId { get; set; }
        public string RndInvnoSup { get; set; } = null!;
        public DateTime RndInvnoSupDate { get; set; }
        public string? ItemList { get; set; }
    }
}
