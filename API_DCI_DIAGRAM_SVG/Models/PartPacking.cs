using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class PartPacking
    {
        public int PpId { get; set; }
        public string? PtPart { get; set; }
        public string? VdAddr { get; set; }
        public string? PpInspect { get; set; }
        public decimal? PpQty { get; set; }
        public decimal? PpWeight { get; set; }
        public decimal? PpWidth { get; set; }
        public decimal? PpLong { get; set; }
        public decimal? PpHeight { get; set; }
        public string? PpType { get; set; }
        public string? PpColor { get; set; }
        public decimal? PpGoodsWeight { get; set; }
        public decimal? PpTotalWeight { get; set; }
        public string? PpSmallPacking { get; set; }
        public string? PpImg { get; set; }
        public decimal? PpShelflife { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? PpPartSize { get; set; }
        /// <summary>
        /// DO Calculation PD Leadtime 
        /// </summary>
        public string? PpLeadtime { get; set; }
        public string? PpCapacity { get; set; }
        public bool? PpBoi { get; set; }
        public decimal? OrderLeadTime { get; set; }
        public decimal? OrderWeight { get; set; }
        /// <summary>
        /// Item Code by Vendor
        /// </summary>
        public string? PpRmk1 { get; set; }
        /// <summary>
        /// DO Minimum Order
        /// </summary>
        public string? PpRmk2 { get; set; }
        /// <summary>
        /// DO Maximum Order
        /// </summary>
        public string? PpRmk3 { get; set; }
        /// <summary>
        /// ShiftPlan
        /// </summary>
        public string? PpRmk4 { get; set; }
        /// <summary>
        /// DO Packing for calculation
        /// </summary>
        public string? PpRmk5 { get; set; }
        /// <summary>
        /// Delivery Cycle of Part Do
        /// </summary>
        public string? PpRmk6 { get; set; }
        /// <summary>
        /// Display OrderBy
        /// </summary>
        public string? PpRmk7 { get; set; }
        public string? PpRmk8 { get; set; }
        public string? PpRmk9 { get; set; }
        public string? PpRmk10 { get; set; }
    }
}
