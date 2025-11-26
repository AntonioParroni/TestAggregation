using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("Projects")]
    public class Projects
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
    }
}
