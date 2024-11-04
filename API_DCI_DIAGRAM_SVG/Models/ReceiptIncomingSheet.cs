using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class ReceiptIncomingSheet
    {
        public string RmNo { get; set; } = null!;
        public string? RmEinvoice { get; set; }
        public DateTime? RmReceiveDate { get; set; }
        public string? RmSupplier { get; set; }
        public string? RmItemNumber { get; set; }
        public string? RmInvoice { get; set; }
        public string? RmReason { get; set; }
        public string? RmDciLot { get; set; }
        public string? RmSupplierLot { get; set; }
        public decimal? RmBoxQty { get; set; }
        public decimal? RmItemQtyPerBox { get; set; }
        public decimal? RmItemTotal { get; set; }
        public decimal? RmItemTotalRe { get; set; }
        public decimal? RmSubTotal { get; set; }
        public decimal? ReceiveQty { get; set; }
        public string? ReceiveBy { get; set; }
        public string? DataVendor { get; set; }
        public string? Appearance { get; set; }
        public string? InspectionType { get; set; }
        public decimal? InspectTotal { get; set; }
        public decimal? InspectOk { get; set; }
        public decimal? InspectNg { get; set; }
        public string? InspectBy { get; set; }
        public DateTime? InspectDate { get; set; }
        public string? InspectLevel { get; set; }
        public string? InspectLotChange { get; set; }
        public decimal? InspectSpecialUseQty { get; set; }
        public int? InspectProblemId { get; set; }
        public decimal? StoreOk { get; set; }
        public decimal? StoreCount { get; set; }
        public string? StoreBy { get; set; }
        public DateTime? StoreDate { get; set; }
        public string? StoreRemark { get; set; }
        public string? StoreLeader { get; set; }
        public string? Status { get; set; }
        public string? Airemark { get; set; }
        public string? Aileader { get; set; }
    }
}
