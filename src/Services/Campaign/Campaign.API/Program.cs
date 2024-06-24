using Common.Logging;
using Campaign.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Campaign.Application;
using Campaign.Infrastructure;
using Campaign.Application.Mappings;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;
using Campaign.API.Extensions;
using Campaign.Infrastructure.Services.Http;
using System.Configuration;
using Campaign.Infrastructure.Services.Http.CustomerApi;
using Campaign.Infrastructure.Services.Http.NotificationApi;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddHttpClient();
builder.Services.Configure<CustomerApiSettings>(builder.Configuration.GetSection("CustomerApi"));
builder.Services.Configure<NotificationApiSettings>(builder.Configuration.GetSection("NotificationApi"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Campaign.API", Version = "v1" });
});
builder.Services.AddHealthChecks()
    .AddDbContextCheck<CampaignContext>();
builder.Host.UseSerilog(SeriLogger.Configure);
var app = builder.Build();

app.MigrateDatabase<CampaignContext>((context, services) =>
{
    var logger = services.GetService<ILogger<CampaignContextSeed>>();
    CampaignContextSeed
        .SeedAsync(context, logger!)
        .Wait();
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Campaign.API v1"));
}

//app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/hc", new HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
