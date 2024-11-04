namespace API_DCI_DIAGRAM_SVG.Models
{
    public class ParamUpdateSequencePlan
    {
        public string empcode { get; set; }
        public string partGroup { get; set; }   
        public List<PropsApsPlanMachine> plan { get; set; } = new List<PropsApsPlanMachine>();
    }
}
