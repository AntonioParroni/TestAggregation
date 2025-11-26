namespace API.DTO;

public class ProjectEmployeeAggregationDTO
{
    public string Project { get; set; } = null!;
    public string Employee { get; set; } = null!;
    public int Hours { get; set; }
}
