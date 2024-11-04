using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoPart
    {
        public int DpId { get; set; }
        public int DryId { get; set; }
        public int RndId { get; set; }
        public decimal DpQty { get; set; }
        public decimal DpPrice { get; set; }
        public decimal DpAmount { get; set; }
        public decimal? QuantitySampling { get; set; }
        public decimal? QuantityOk { get; set; }
        public decimal? QuantityNg { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public int DpStatus { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? PoNbr { get; set; }
        public string? PodDetId { get; set; }
        public string? PtPart { get; set; }
        public DateTime? DoDueDate { get; set; }
        /// <summary>
        /// SI, Q, INS
        /// </summary>
        public string? PartType { get; set; }
        public string? PartLotno { get; set; }
        /// <summary>
        /// PO Line
        /// </summary>
        public string? DoRmk1 { get; set; }
        public string? DoRmk2 { get; set; }
        public string? DoRmk3 { get; set; }
        public string? DoRmk4 { get; set; }
        public string? DoRmk5 { get; set; }
    }
}
