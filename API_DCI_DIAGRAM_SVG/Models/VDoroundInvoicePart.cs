using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class VDoroundInvoicePart
    {
        public int RndId { get; set; }
        public int? DryId { get; set; }
        public DateTime? RndDate { get; set; }
        public string? RndTime { get; set; }
        public string? RndInvno { get; set; }
        public string? RndLotno { get; set; }
        public int? RndStatus { get; set; }
        public string RndInvnoSup { get; set; } = null!;
        public DateTime RndInvnoSupDate { get; set; }
        public string? Remark { get; set; }
        public string? PtPart { get; set; }
        public int? DpId { get; set; }
        public decimal? DpQty { get; set; }
        public decimal? DpPrice { get; set; }
        public decimal? DpAmount { get; set; }
        public decimal? QuantitySampling { get; set; }
        public decimal? QuantityOk { get; set; }
        public decimal? QuantityNg { get; set; }
        public int? DpStatus { get; set; }
        public string? PoNbr { get; set; }
        public string? PodDetId { get; set; }
        public DateTime? DoDueDate { get; set; }
        public string? PartType { get; set; }
    }
}
