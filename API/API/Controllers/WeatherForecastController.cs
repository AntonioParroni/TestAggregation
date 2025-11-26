using API.DTO;
using API.Interfaces;
using API.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        private readonly IEmploymentRepository _employmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IEmploymentRepository employmentRepository, IMapper mapper)
        {
            _logger = logger;
            _employmentRepository = employmentRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<ActivitiesDTO>> GetAsync()
        {
            var cities = await _employmentRepository.NoAggregationAsync();
            return cities;
        }
    }
}
