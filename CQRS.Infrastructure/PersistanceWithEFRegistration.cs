using CQRS.Application.Contracts.Persistance;
using CQRS.InfrastructureEF.Repositories;
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

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            //services.AddScoped<IWebinarRepository, WebinarRepository>();



            //services.AddScoped<CQRSAppContext>(provider => provider.GetRequiredService<CQRSAppContext>());

            return services;
        }
    }
}
