using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Vericode.Domain.Configurations;
using Vericode.Infra.CrossCutting;
using Vericode.Api.Security.Configurations;
using Vericode.Api.Security;
using Vericode.Api.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddCors();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddJwtBearerAuthentication(configuration);

var cryptographySettings = builder.Configuration.GetSection("CryptographySettings").Get<CryptographySettings>();
builder.Services.AddSingleton(cryptographySettings);

var authenticationSettings = builder.Configuration.GetSection("AuthenticationSettings").Get<AuthenticationSettings>();
builder.Services.AddSingleton(authenticationSettings);

var rabbitMQSettings = builder.Configuration.GetSection("RabbitMQSettings").Get<RabbitMQSettings>();
builder.Services.AddSingleton(rabbitMQSettings);

var jwtBearerToken = new JwtBearerToken(authenticationSettings);
builder.Services.AddSingleton(jwtBearerToken);

builder.Services.RegisterCrossCuttingDependencies(configuration);

var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MappingProfile()));
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.UseCors(x => x.SetIsOriginAllowed(origin => true)
.AllowAnyHeader()
.AllowAnyMethod()
.AllowCredentials());

app.MapControllers();

app.Run();
