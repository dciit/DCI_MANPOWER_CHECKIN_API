using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class Pu6Poforecast
    {
        public long Id { get; set; }
        public string? ForecastNbr { get; set; }
        public string ForecastSet { get; set; } = null!;
        public string? VdSort { get; set; }
        public string VdAddr { get; set; } = null!;
        public string PtPart { get; set; } = null!;
        public string? PtDesc1 { get; set; }
        public string PtUm { get; set; } = null!;
        public decimal? PackStdQty { get; set; }
        public string OrderType { get; set; } = null!;
        public int Revision { get; set; }
        public string? Month1stCode { get; set; }
        public decimal? Month1st { get; set; }
        public string? Month1ndCode { get; set; }
        public decimal? Month1nd { get; set; }
        public string? Month2stCode { get; set; }
        public decimal? Month2st { get; set; }
        public string? Month2ndCode { get; set; }
        public decimal? Month2nd { get; set; }
        public string? Month3stCode { get; set; }
        public decimal? Month3st { get; set; }
        public string? Month3ndCode { get; set; }
        public decimal? Month3nd { get; set; }
        public string? Month4stCode { get; set; }
        public decimal? Month4st { get; set; }
        public string? Month4ndCode { get; set; }
        public decimal? Month4nd { get; set; }
        public string? Month5stCode { get; set; }
        public decimal? Month5st { get; set; }
        public string? Month5ndCode { get; set; }
        public decimal? Month5nd { get; set; }
        public string? Month6stCode { get; set; }
        public decimal? Month6st { get; set; }
        public string? Month6ndCode { get; set; }
        public decimal? Month6nd { get; set; }
        public string? Month7stCode { get; set; }
        public decimal? Month7st { get; set; }
        public string? Month7ndCode { get; set; }
        public decimal? Month7nd { get; set; }
        public string? Month8stCode { get; set; }
        public decimal? Month8st { get; set; }
        public string? Month8ndCode { get; set; }
        public decimal? Month8nd { get; set; }
        public string? Month9stCode { get; set; }
        public decimal? Month9st { get; set; }
        public string? Month9ndCode { get; set; }
        public decimal? Month9nd { get; set; }
        public string? Month10stCode { get; set; }
        public decimal? Month10st { get; set; }
        public string? Month10ndCode { get; set; }
        public decimal? Month10nd { get; set; }
        public string? Month11stCode { get; set; }
        public decimal? Month11st { get; set; }
        public string? Month11ndCode { get; set; }
        public decimal? Month11nd { get; set; }
        public string? Month12stCode { get; set; }
        public decimal? Month12st { get; set; }
        public string? Month12ndCode { get; set; }
        public decimal? Month12nd { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateBy { get; set; }
        /// <summary>
        /// PUBLISH, UNPUBLISH
        /// </summary>
        public string DataStatus { get; set; } = null!;
        public string? ApproveSuby { get; set; }
        public DateTime? ApproveSudate { get; set; }
        public string? ApproveMgby { get; set; }
        public DateTime? ApproveMgdate { get; set; }
        public string? ApproveGmby { get; set; }
        public DateTime? ApproveGmdate { get; set; }
        public string? ApproveDiby { get; set; }
        public DateTime? ApproveDidate { get; set; }
        public string? IssueBy { get; set; }
        public string? StatusApprove { get; set; }
    }
}
