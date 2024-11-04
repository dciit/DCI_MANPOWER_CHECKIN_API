using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class VPlanDeliveryOrder
    {
        public int RndId { get; set; }
        public int DryId { get; set; }
        public string SupplierNo { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Month { get; set; } = null!;
        public int DryRev { get; set; }
        public DateTime? DryRevDate { get; set; }
        public string? DryRevBy { get; set; }
        public DateTime RndDate { get; set; }
        public string RndTime { get; set; } = null!;
        public string? RndInvno { get; set; }
        public string? RndLotno { get; set; }
        public int RndStatus { get; set; }
        public string? RndInvnoSup { get; set; }
        public int? PartQty { get; set; }
        public string? StatusName { get; set; }
        public DateTime? RndInvnoSupDate { get; set; }
        public string? Remark { get; set; }
        public string? VdSort { get; set; }
    }
}
