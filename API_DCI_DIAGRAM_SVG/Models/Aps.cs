namespace API_DCI_DIAGRAM_SVG.Models
{
    public class Aps
    {
        public string type { get; set; }   // start time, plan, now, actual, diff, other
        public string wcno { get; set; }   // 90?.27?
        public double value { get; set; } = 0.0;
    }
}
