using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Vericode.Api.Mapping;
using Vericode.Api.Security;
using Vericode.Api.Security.Configurations;
using Vericode.Domain.Configurations;

namespace Vericode.Api.AppResolver
{
    public static class DependencyResolver
    {
        public static IServiceCollection RegisterAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddJwtBearerAuthentication(configuration);

            var cryptographySettings = configuration.GetSection("CryptographySettings").Get<CryptographySettings>();
            services.AddSingleton(cryptographySettings);

            var authenticationSettings = configuration.GetSection("AuthenticationSettings").Get<AuthenticationSettings>();
            services.AddSingleton(authenticationSettings);

            var rabbitMQSettings = configuration.GetSection("RabbitMQSettings").Get<RabbitMQSettings>();
            services.AddSingleton(rabbitMQSettings);

            var jwtBearerToken = new JwtBearerToken(authenticationSettings);
            services.AddSingleton(jwtBearerToken);

            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddHostedService<Worker.WorkerService.Worker>();

            services.AddLogging(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Trace));

            return services;
        }
    }
}
