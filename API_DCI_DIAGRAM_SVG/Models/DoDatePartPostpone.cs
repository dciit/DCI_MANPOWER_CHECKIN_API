using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoDatePartPostpone
    {
        public int Id { get; set; }
        public string? SupplierNo { get; set; }
        public int? FromDryId { get; set; }
        public int? ToDryId { get; set; }
        public DateTime? FromDoDate { get; set; }
        public DateTime? ToDoDate { get; set; }
        public string? PtPart { get; set; }
        public string? PoNbr { get; set; }
        public int? PoLine { get; set; }
        public decimal? FromDoQty { get; set; }
        public decimal? ToDoQty { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Reason { get; set; }
        public string? DoRmk1 { get; set; }
        public string? DoRmk2 { get; set; }
        public string? DoRmk3 { get; set; }
        public string? DoRmk4 { get; set; }
        public string? DoRmk5 { get; set; }
    }
}
