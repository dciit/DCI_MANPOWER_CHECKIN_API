using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class SkcUserInRole
    {
        public string PriRole { get; set; } = null!;
        public string PriEmpcode { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
    }
}
