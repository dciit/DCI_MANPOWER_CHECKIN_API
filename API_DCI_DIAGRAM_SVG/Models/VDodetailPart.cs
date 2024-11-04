using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class VDodetailPart
    {
        public int DryId { get; set; }
        public string SupplierNo { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string Month { get; set; } = null!;
        public int DryRev { get; set; }
        public DateTime? DryRevDate { get; set; }
        public string? DryRevBy { get; set; }
        public int RndId { get; set; }
        public DateTime RndDate { get; set; }
        public string RndTime { get; set; } = null!;
        public string? RndInvno { get; set; }
        public string? RndLotno { get; set; }
        public int RndStatus { get; set; }
        public string? RndInvnoSup { get; set; }
        public int DpId { get; set; }
        public decimal DpQty { get; set; }
        public decimal DpPrice { get; set; }
        public decimal DpAmount { get; set; }
        public int DpStatus { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        public string? StatusName { get; set; }
        public string? PoNbr { get; set; }
        public string? PtPart { get; set; }
        public string? PodDetId { get; set; }
        public DateTime? RndInvnoSupDate { get; set; }
        public string? Remarks { get; set; }
        public string? PpInspect { get; set; }
        public decimal? PpQty { get; set; }
        public string? TypeName { get; set; }
        public string? TypeDescription { get; set; }
        public DateTime? DoDueDate { get; set; }
        public string? PtDesc2 { get; set; }
        public string? PtDesc1 { get; set; }
        public string? PtUm { get; set; }
        public string? PtDraw { get; set; }
        public string? PtLoc { get; set; }
        public string? PpImg { get; set; }
        public string? PartType { get; set; }
    }
}
