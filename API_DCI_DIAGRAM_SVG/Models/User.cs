using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class User
    {
        public int? Id { get; set; }
        public string? UserId { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Nickname { get; set; }
        public string? Tel { get; set; }
        public int? Status { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
