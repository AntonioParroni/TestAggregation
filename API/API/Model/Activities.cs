using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{

    [Table("Activities")]
    public class Activities
    {
        [Key]
        public int ActivityId { get; set; }

        [ForeignKey("ProjectId")]
        [Column("ProjectId")]
        public Projects Project { get; set; }

        [ForeignKey("EmployeeId")]
        [Column("EmployeeId")]
        public Employment Employment { get; set; }
        public int Hours { get; set; }

        public DateTime ActivityDate { get; set; }
    }
}
