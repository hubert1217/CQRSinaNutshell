using CQRS.Application;
using CQRS.Infrastructure.Security;
using CQRS.InfrastructureEF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
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
                .AddSecurityServices(builder.Configuration)
                .AddSwagger()
                .AddControllers();
            
            return builder;
        }

        private static IServiceCollection AddSwagger(this IServiceCollection services) 
        {
            services
                .AddSwaggerGen(c => 
                {
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Wprowadź token w formacie: Bearer {token}"
                    });

                    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme="oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                        }   
                    });
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "CQRS API"
                    });
                })
                .AddEndpointsApiExplorer();

            return services;
        } 
    }
}
