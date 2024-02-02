using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Table("MPCK_Layout")]
    [Index(nameof(Factory), nameof(Line), nameof(SubLine), Name = "IX_MPCK_Layout")]
    public partial class MpckLayout
    {
        [Key]
        [StringLength(20)]
        public string LayoutCode { get; set; } = null!;
        [StringLength(50)]
        public string? LayoutName { get; set; }
        [StringLength(100)]
        public string? LayoutSubName { get; set; }
        [StringLength(10)]
        public string? Factory { get; set; }
        [StringLength(10)]
        public string? Line { get; set; }
        [StringLength(20)]
        public string? SubLine { get; set; }
        [StringLength(10)]
        public string? LayoutStatus { get; set; }
        [Column("BypassMQ")]
        [StringLength(10)]
        public string? BypassMq { get; set; }
        [Column("BypassSA")]
        [StringLength(10)]
        public string? BypassSa { get; set; }
        [StringLength(5)]
        public string? UpdateBy { get; set; }


        public double? Width { get; set; }   
        public double? Height { get; set; }
        /// <summary>
        /// CURRENT_TIMESTAMP
        /// </summary>
        [Column(TypeName = "datetime")]
        public DateTime? UpdateDate { get; set; }
    }
}
