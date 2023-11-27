using Vericode.Infra.CrossCutting;
using Vericode.Api.Security.Configurations;
using Vericode.Api.AppResolver;
using Microsoft.Extensions.Logging.EventLog;
using Vericode.Worker.Hubs;
using Vericode.Worker.WorkerResolver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddSignalR();

builder.Host.ConfigureLogging(loggingBuilder =>
{
    loggingBuilder.ClearProviders();
    loggingBuilder.AddDebug();
    loggingBuilder.AddConsole();
    loggingBuilder.AddEventLog();
    loggingBuilder.AddFilter<EventLogLoggerProvider>(level => level != LogLevel.None);
});

ConfigurationManager configuration = builder.Configuration;

builder.Services.RegisterAppDependencies(configuration);
builder.Services.RegisterCrossCuttingDependencies(configuration);

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

app.UseCors("CorsPolicy");

//app.UseCors(x => x.SetIsOriginAllowed(origin => true)
//.AllowAnyHeader()
//.AllowAnyMethod()
//.AllowCredentials());

app.MapControllers();
app.MapHub<TaskHub>("/hub/task");

app.Run();
