using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CQRS.InfrastructureEF
{
    public static class PersistanceWithEFRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CQRSAppContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CQRSConnectionString")));

            //services.AddScoped<CQRSAppContext>(provider => provider.GetRequiredService<CQRSAppContext>());

            return services;
        }
    }
}
