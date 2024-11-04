using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class DoDelivery
    {
        public int DelId { get; set; }
        public int DoId { get; set; }
        /// <summary>
        /// วันที่จัดส่ง
        /// </summary>
        public string DelDt { get; set; } = null!;
        /// <summary>
        /// ยอด D/O เดิม
        /// </summary>
        public int? DelDo { get; set; }
        /// <summary>
        /// ยอดรับ
        /// </summary>
        public int? DelInput { get; set; }
        /// <summary>
        /// WH1 || WH2
        /// </summary>
        public string? DelWh { get; set; }
        /// <summary>
        /// 999 = ใช้งาน
        /// </summary>
        public int? DelLrev { get; set; }
        public DateTime? DelCreateDt { get; set; }
        public string? DelCreateBy { get; set; }
        public DateTime? DelUpdateDt { get; set; }
        public string? DelUpdateBy { get; set; }
    }
}
