using API.DTO;
using API.Model;

namespace API.Interfaces;

public interface IEmploymentRepository
{
    Task<IEnumerable<ActivitiesDTO>> NoAggregationAsync();
    Task<IEnumerable<Activities>> AggregationByProjectAsync();
    Task<IEnumerable<Activities>> AggregationByProjectAndEmployeeAsync();
    Task<IEnumerable<Activities>> AggregationByEmployeeAndProjectAsync();
}