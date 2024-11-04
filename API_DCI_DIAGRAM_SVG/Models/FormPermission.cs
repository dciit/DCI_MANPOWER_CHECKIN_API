using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class FormPermission
    {
        public int Id { get; set; }
        public int? FormId { get; set; }
        public int? GroupId { get; set; }
        public short? View1 { get; set; }
        public short? View2 { get; set; }
        public short? View3 { get; set; }
        public short? View4 { get; set; }
        public short? Add1 { get; set; }
        public short? Add2 { get; set; }
        public short? Add3 { get; set; }
        public short? Add4 { get; set; }
        public short? Edit1 { get; set; }
        public short? Edit2 { get; set; }
        public short? Edit3 { get; set; }
        public short? Edit4 { get; set; }
        public short? Delete1 { get; set; }
        public short? Delete2 { get; set; }
        public short? Delete3 { get; set; }
        public short? Delete4 { get; set; }
        public short? Active1 { get; set; }
        public short? Active2 { get; set; }
        public short? Active3 { get; set; }
        public short? Active4 { get; set; }
        public short? Approve1 { get; set; }
        public short? Approve2 { get; set; }
        public short? Approve3 { get; set; }
        public short? Approve4 { get; set; }
        public short? Other1 { get; set; }
        public short? Other2 { get; set; }
        public short? Other3 { get; set; }
        public short? Other4 { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
