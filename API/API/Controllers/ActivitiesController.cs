using API.DTO;
using API.Interfaces;
using API.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IEmploymentRepository _employmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ActivitiesController> _logger;

        public ActivitiesController(ILogger<ActivitiesController> logger, IEmploymentRepository employmentRepository, IMapper mapper)
        {
            _logger = logger;
            _employmentRepository = employmentRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "aggregation/default")]
        public async Task<IEnumerable<ActivitiesDTO>> GetAsync()
        {
            var cities = await _employmentRepository.NoAggregationAsync();
            return cities;
        }

        [HttpGet("aggregation/by-project")]
        public async Task<IEnumerable<ProjectAggregationDTO>> GetAggregationByProject()
        {
            var cities = await _employmentRepository.AggregationByProjectAsync();
            return cities;
        }
    }
}
