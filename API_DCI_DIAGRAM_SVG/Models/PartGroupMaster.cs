namespace API_DCI_DIAGRAM_SVG.Models
{
    public class PartGroupMaster
    {
        public string wcno { get; set; }
        public string model_common { get; set; }
        public string partno { get; set; }
        public string cm { get; set; }
        public string part_group { get; set; }
        public string part_group_name { get;set; }

        public string modelcode { get; set; }

        public int stdMC { get; set; } = 0;
        public int stdCTMC { get; set; } = 0;
        public int stdCT { get; set; } = 0;
        public int stdCapHR { get; set; } = 0;  
        public int stdCapShift { get; set; } = 0;
        public int stdCapDay { get; set; } = 0;
        public int stdNeedDay { get; set; } = 0;
    }
}
