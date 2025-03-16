namespace Ordering.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            //Add services for carter

            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            //app.mapcarter()

            return app;
        }
    }
}
