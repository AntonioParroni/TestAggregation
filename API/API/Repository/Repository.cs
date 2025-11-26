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


    // Aggregazione per Project + Employee (Project, Employee, TotalHours)
    public async Task<IEnumerable<ProjectEmployeeAggregationDTO>> AggregationByProjectAndEmployeeAsync()
    {
        var query = _context.Activities
            .AsNoTracking()
            .GroupBy(a => new { ProjectName = a.Project.Name, EmployeeName = a.Employment.Name })
            .Select(g => new ProjectEmployeeAggregationDTO
            {
                Project = g.Key.ProjectName,
                Employee = g.Key.EmployeeName,
                TotalHours = g.Sum(x => x.Hours)
            });

        return await query.ToListAsync();
    }



    // Aggregazione per Employee + Project (stesso risultato della precedente ma ordinamento diverso)
    public async Task<IEnumerable<Activities>> AggregationByEmployeeAndProjectAsync()
    {
        var query = _context.Activities
            .AsNoTracking()
            .Include(a => a.Project)
            .Include(a => a.Employment)
            .GroupBy(a => new { EmployeeId = a.Employment.EmployeeId, EmployeeName = a.Employment.Name, ProjectId = a.Project.ProjectId, ProjectName = a.Project.Name })
            .Select(g => new Activities
            {
                Project = new Projects { ProjectId = g.Key.ProjectId, Name = g.Key.ProjectName },
                Employment = new Employment { EmployeeId = g.Key.EmployeeId, Name = g.Key.EmployeeName },
                Hours = g.Sum(x => x.Hours),
                ActivityDate = default
            });

        return await query.ToListAsync();
    }

    // "No aggregation" — proietta verso ActivitiesDTO usando AutoMapper (efficiente)
    public async Task<IEnumerable<ActivitiesDTO>> NoAggregationAsync()
    {
        return await _context.Activities
           .AsNoTracking()
           .Include(a => a.Project)
           .Include(a => a.Employment)
           .ProjectTo<ActivitiesDTO>(_mapper.ConfigurationProvider)
           .ToListAsync();
    }

    // Aggregazione per Project (solo somma delle ore per progetto)

    public async Task<IEnumerable<ProjectAggregationDTO>> AggregationByProjectAsync()
    {
        // Raggruppa per nome progetto e somma le ore lato database
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