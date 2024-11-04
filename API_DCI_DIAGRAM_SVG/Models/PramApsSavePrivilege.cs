namespace API_DCI_DIAGRAM_SVG.Models
{
    public class PramApsSavePrivilege
    {
        public string empcode { get; set; }
        public string? privilege { get; set; }
        public string updateBy { get; set; }
        public List<string> wcno { get; set; } = new List<string>();
    }
}
