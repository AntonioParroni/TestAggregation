using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    [Table("Employment")]
    public class Employment
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }

    }
}
