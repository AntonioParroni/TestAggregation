using API.DTO;
using API.Interfaces;
using API.Model;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using API.DTO;
using API.Interfaces;
using API.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class EmploymentRepository : IEmploymentRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public EmploymentRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectEmployeeAggregationDTO>> AggregationByProjectAndEmployeeAsync()
    {
        var query = _context.Activities
            .AsNoTracking()
            .GroupBy(a => new { ProjectName = a.Project.Name, EmployeeName = a.Employment.Name })
            .Select(g => new ProjectEmployeeAggregationDTO
            {
                Project = g.Key.ProjectName,
                Employee = g.Key.EmployeeName,
                Hours = g.Sum(x => x.Hours)
            });

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<EmployeeProjectAggregationDTO>> AggregationByEmployeeAndProjectAsync()
    {
        var query = _context.Activities
            .AsNoTracking()
            .GroupBy(a => new { EmployeeName = a.Employment.Name, ProjectName = a.Project.Name })
            .Select(g => new EmployeeProjectAggregationDTO
            {
                Employee = g.Key.EmployeeName,
                Project = g.Key.ProjectName,
                Hours = g.Sum(x => x.Hours)
            }) 
            .OrderBy(r => r.Employee).ThenBy(r => r.Project);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<ActivitiesDTO>> NoAggregationAsync()
    {
        return await _context.Activities
           .AsNoTracking()
           .Include(a => a.Project)
           .Include(a => a.Employment)
           .ProjectTo<ActivitiesDTO>(_mapper.ConfigurationProvider)
           .ToListAsync();
    }

    public async Task<IEnumerable<ProjectAggregationDTO>> AggregationByProjectAsync()
    {
        var query = _context.Activities
            .AsNoTracking()
            .GroupBy(a => a.Project.Name)
            .Select(g => new ProjectAggregationDTO
            {
                ProjectName = g.Key,
                TotalHours = g.Sum(x => x.Hours)
            });

        return await query.ToListAsync();
    }
}