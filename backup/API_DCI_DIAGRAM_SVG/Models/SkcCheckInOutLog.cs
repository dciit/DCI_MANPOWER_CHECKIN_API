﻿using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class SkcCheckInOutLog
    {
        public int ChkId { get; set; }
        public string? DictCode { get; set; }
        public string? ChkEmpcode { get; set; }
        /// <summary>
        /// in or out
        /// </summary>
        public string? ChkState { get; set; }
        public DateTime? ChkDate { get; set; }
    }
}
