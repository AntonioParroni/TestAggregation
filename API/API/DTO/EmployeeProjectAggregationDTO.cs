namespace API.DTO
{
    public class EmployeeProjectAggregationDTO
    {
        public string Employee { get; set; } = null!;
        public string Project { get; set; } = null!;
        public int Hours { get; set; }
    }
}
