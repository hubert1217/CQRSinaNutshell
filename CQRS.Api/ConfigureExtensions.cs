using CQRS.Application;
using CQRS.InfrastructureEF;
using System.Runtime.CompilerServices;

namespace CQRS.Api
{
    public static class ConfigureExtensions
    {
        public static WebApplicationBuilder ConfigureApplication(this WebApplicationBuilder builder)
        {

            builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration)
                .AddSwagger()
                .AddControllers();
            
            return builder;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services) 
        {
            services
                .AddSwaggerGen()
                .AddEndpointsApiExplorer();

            return services;
        } 
    }
}
