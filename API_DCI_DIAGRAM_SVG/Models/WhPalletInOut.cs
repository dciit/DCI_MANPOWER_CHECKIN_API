using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class WhPalletInOut
    {
        public int PalletInOutId { get; set; }
        public string? PalletNo { get; set; }
        public int? TrackNo { get; set; }
        public string? TrackStatus { get; set; }
        public string? Model { get; set; }
        public string? ModelCode { get; set; }
        public int? PalletStatusId { get; set; }
        public int? PalletLocationId { get; set; }
        public string? Status { get; set; }
        public string? Remark { get; set; }
        public string? Detail { get; set; }
        public string? Incharge { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
