using API.DTO;
using API.Model;

namespace API.Interfaces;

public interface IEmploymentRepository
{
    Task<IEnumerable<ActivitiesDTO>> NoAggregationAsync();
    Task<IEnumerable<ProjectAggregationDTO>> AggregationByProjectAsync();
    Task<IEnumerable<ProjectEmployeeAggregationDTO>> AggregationByProjectAndEmployeeAsync();
    Task<IEnumerable<EmployeeProjectAggregationDTO>> AggregationByEmployeeAndProjectAsync();
}