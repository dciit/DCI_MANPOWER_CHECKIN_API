namespace API_DCI_DIAGRAM_SVG.Models
{
    public class WipProps
    {
        public string model { get;set; }
        public string sebango { get;set; }
        public string partno { get;set; }
        public string parttype { get; set; }
        public string hour { get; set; }
        public double cnt { get; set; } = 0;
        public List<PartProps> wip { get; set; } = new List<PartProps>();
    }

    public class PartProps
    {
        public string wcno { get; set; }    
        public string model { get; set; }   
        public string partno { get; set; }
        public decimal? stock { get; set; } = 0;
        public string parttype { get; set; }    
    }
}
