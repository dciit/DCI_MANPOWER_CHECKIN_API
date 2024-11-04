using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViItemInvoiceStatus
    {
        public string? RndInvno { get; set; }
        public decimal DpQty { get; set; }
        public int DpStatus { get; set; }
        public string? StatusName { get; set; }
        public string? Remarks { get; set; }
        public string? PoNbr { get; set; }
        public string? PodDetId { get; set; }
        public string? PtPart { get; set; }
        public string? RndLotno { get; set; }
        public decimal DpPrice { get; set; }
        public decimal DpAmount { get; set; }
        public int DryId { get; set; }
        public int RndId { get; set; }
        public DateTime RndDate { get; set; }
        public string RndTime { get; set; } = null!;
        public string? RndInvnoSup { get; set; }
        public DateTime? RndInvnoSupDate { get; set; }
    }
}
