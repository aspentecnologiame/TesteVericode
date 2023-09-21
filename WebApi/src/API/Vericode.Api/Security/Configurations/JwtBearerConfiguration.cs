using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Vericode.Api.Security.Requirements;
using Vericode.Domain.Configurations;

namespace Vericode.Api.Security.Configurations
{
    public static class JwtBearerConfiguration
    {
        public static IServiceCollection AddJwtBearerAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["AuthenticationSettings:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = configuration["AuthenticationSettings:Audience"],

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthenticationSettings:SecretKey"])),

                    RequireExpirationTime = false,
                    ValidateLifetime = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSingleton<IAuthorizationHandler, RoleRequirementHandler>();

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy(
                    "Bearer",
                    new AuthorizationPolicyBuilder()
                        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .Build()
                );

                auth.AddPolicy("HasRole", police => police.Requirements.Add(new RoleRequirement()));

            });

            return services;
        }
    }
}
