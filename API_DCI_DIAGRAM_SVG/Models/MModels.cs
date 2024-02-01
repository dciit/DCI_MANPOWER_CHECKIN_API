namespace API_DCI_DIAGRAM_SVG.Models
{
    public class MModels
    {
        public class MManSkill
        {
            public string? counter {  get; set; }
            public List<Employee>? employees { get; set; }   
            public string? objCode { get; set; } // รหัส object  tb:mpck col:obj_Code
        }
    }
}
