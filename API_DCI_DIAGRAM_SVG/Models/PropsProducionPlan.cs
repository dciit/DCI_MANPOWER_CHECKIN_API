namespace API_DCI_DIAGRAM_SVG.Models
{
    public class PropsProducionPlan
    {
        public string wcno { get; set; }
        public string prdPlanCode { get; set; }
        public string partNo { get; set; }
        public string cm {  get; set; } 
        public string apsSeq { get; set; }
        public string subLine { get; set; }
        public string prdSeq { get; set; }
        public decimal result { get; set; } = 0;
        public decimal estSet { get; set; } = 0;
        public decimal safety { get; set; } = 0;
        public decimal apsPlanQty { get; set; } = 0;
        public decimal prdPlanQty { get; set; } = 0;
        public decimal statorMain { get; set; } = 0;
        public decimal statorMotor { get; set; } = 0;
        public decimal rotorMain { get; set; } = 0;
        public decimal rotorMotor { get; set; } = 0;
        public decimal housingMain { get; set; } = 0;
        public decimal housingMC { get; set; } = 0;

        public decimal csMain { get; set; } = 0;
        public decimal csMC { get; set; } = 0;
        public decimal fsosMain { get; set; } = 0;
        public decimal fsosMC { get; set; } = 0;

        public decimal lwMain { get; set; } = 0;
        public decimal lwMC { get; set; } = 0;

        public decimal bodyMain { get; set; } = 0;
        public decimal bodyCasing { get; set; } = 0;

        public decimal topMain { get; set; } = 0;
        public decimal topCasing { get; set; } = 0;
        public decimal bottomMain { get; set; } = 0;
        public decimal bottomCasing { get; set; } = 0;
    }
}
