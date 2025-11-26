using API.Model;

namespace API.DTO
{
    public class ActivitiesDTO
    {
        public int ActivityId { get; set; }
        public string Project { get; set; }
        public string Employment { get; set; }
        public int Hours { get; set; }
        public DateOnly? Date { get; set; }
    }
}
