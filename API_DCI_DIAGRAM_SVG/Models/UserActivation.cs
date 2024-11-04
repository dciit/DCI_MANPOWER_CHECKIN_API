using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class UserActivation
    {
        public int UserId { get; set; }
        public Guid ActivationCode { get; set; }
    }
}
