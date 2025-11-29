using API.Data;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IEmploymentRepository, EmploymentRepository>();
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });
        services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
        return services;
    }
}