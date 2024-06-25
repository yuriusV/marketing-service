using Notification.Infrastructure;
using Notification.Application;
using Microsoft.OpenApi.Models;
using Serilog;
using Common.Logging;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using FluentValidation.AspNetCore;
using Notification.API.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Notification.API", Version = "v1" });
});
builder.Services.AddHealthChecks();
builder.Host.UseSerilog(SeriLogger.Configure);
var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notification.API v1"));
    app.UseMiddleware<ErrorsLoggingMiddleware>();
}

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/hc", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
