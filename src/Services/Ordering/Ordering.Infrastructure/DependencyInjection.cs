using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Ordering.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("Database");

            // Add services to container 

            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.usersqlserver(connectionstring));



            return services;
        }
    }
}
