using System;
using System.Collections.Generic;

namespace API_DCI_DIAGRAM_SVG.Models
{
    public partial class VAdamLocation
    {
        public string? PtPart { get; set; }
        public short? PartActive { get; set; }
        public int? ChanelNumber { get; set; }
        public int? SlotNumber { get; set; }
        public string? Ipaddress { get; set; }
        public int? ColorNo { get; set; }
        public short? AdamActive { get; set; }
        public string? LocationShortName { get; set; }
        public string? LocationName { get; set; }
        public string? ZoneShortName { get; set; }
        public string? ZoneName { get; set; }
        public string? ZoneGroupShortName { get; set; }
        public string? ZoneGroupName { get; set; }
        public string? FactoryName { get; set; }
        public string? FactoryShortName { get; set; }
        public string? ColorName { get; set; }
        public string? VdAddr { get; set; }
    }
}
