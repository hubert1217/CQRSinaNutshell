using CQRS.Application.Security.Contracts;
using CQRS.Application.Security.Models;
using CQRS.Infrastructure.Security.Manager;
using CQRS.Infrastructure.Security.Models;
using CQRS.Infrastructure.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Infrastructure.Security
{
    public static class SecurityServiceExtensions
    {
        public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.Configure<JSONWebTokensSettings>(configuration.GetSection("JSONWebTokensSettings"));


            services.AddSingleton<IUserManager<User>, UserManager>();
            services.AddSingleton<ISignInManager<User>, SignInManager>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();




            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => 
            { 
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JSONWebTokensSettings:Issuer"],
                    ValidAudience = configuration["JSONWebTokensSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JSONWebTokensSettings:Key"]))
                };

                o.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = c =>
                    {
                        c.NoResult();
                        c.Response.StatusCode = 500;
                        c.Response.ContentType = "text/plain";
                        return c.Response.WriteAsync(c.Exception.ToString());
                    },
                    OnChallenge = context =>
                    {
                        context.HandleResponse();
                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject("401 Not found");
                        return context.Response.WriteAsync(result);
                    },
                    OnForbidden = context =>
                    {
                        context.Response.StatusCode = 403;
                        context.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject("403 Not found");
                        return context.Response.WriteAsync(result);

                    }

                };
            });

            return services;

        }
    }
}
