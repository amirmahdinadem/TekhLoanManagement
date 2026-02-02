using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Serilog;
using TekhLoanManagement.Api.Extensions.ApplicationBuilder;
using TekhLoanManagement.Api.Extensions.ServiceCollection;
using TekhLoanManagement.Api.HealthChecks;
using TekhLoanManagement.Infrastructure.Identity;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    //.WriteTo.File("logs/api-log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddCustomMediatR()
    .AddValidation()
    .AddInfrastructure(builder.Configuration)
    .AddApplicationServices()
    .AddCustomCors(builder.Configuration)
    .AddJwtAuthentication(builder.Configuration)
    .AddAuthorizationPolicies()
    .AddSwaggerDocumentation()
    .AddRateLimiting(builder.Configuration)
    .AddCustomHealthChecks(builder.Configuration);


var app = builder.Build();
using(var scope = app.Services.CreateScope())
{
    var services=scope.ServiceProvider;
    await IdentitySeed.SeedAdminAsync(services);
}

app.UseCustomMiddlewares();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();

}

app.UseHttpsRedirection();
app.UseCors("DevCors");
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.MapControllers();

app.MapHealthChecks("/health",
     new HealthCheckOptions
     {
         ResponseWriter = HealthCheckResponses.WriteResponse
     });

app.MapHealthChecks("/health/ready", new HealthCheckOptions
{
    Predicate = healthCheck => healthCheck.Tags.Contains("ready"),
    ResponseWriter = HealthCheckResponses.WriteResponse
});

app.MapHealthChecks("/health/live", new HealthCheckOptions
{
    Predicate = _ => false,
});

app.Logger.LogInformation("LAUNCHING TekhLoanManagement.Api");

app.Run();
