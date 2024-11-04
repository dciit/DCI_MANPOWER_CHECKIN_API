using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ViSupplierInvoice
    {
        public int RndId { get; set; }
        public int DryId { get; set; }
        public DateTime RndDate { get; set; }
        public string RndTime { get; set; } = null!;
        public string? RndInvno { get; set; }
        public string? RndLotno { get; set; }
        public int RndStatus { get; set; }
        public string? RndInvnoSup { get; set; }
        public DateTime? RndInvnoSupDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Remark { get; set; }
        public string? VdPurCntct { get; set; }
        public string? VdSort { get; set; }
        public string? VdShipvia { get; set; }
        public string? AdLine1 { get; set; }
        public string? AdLine2 { get; set; }
        public string? AdLine3 { get; set; }
        public string? AdFax { get; set; }
        public string? AdFax2 { get; set; }
        public string? AdPhone2 { get; set; }
        public string? AdAttn2 { get; set; }
        public string? AdCountry { get; set; }
        public string? AdPhone { get; set; }
        public string? AdAttn { get; set; }
        public string? AdZip { get; set; }
        public string? AdState { get; set; }
        public string? AdCity { get; set; }
        public string? AdName { get; set; }
        public string? AdType { get; set; }
        public string SupplierNo { get; set; } = null!;
    }
}
