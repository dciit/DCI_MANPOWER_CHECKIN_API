using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API_DCI_DIAGRAM_SVG.Models
{
    [Keyless]
    public class SpDCRunNbr
    {

        [Column("RunNbr")]
        [StringLength(100)]
        public string RunNbr { get; set; }
    }
}
