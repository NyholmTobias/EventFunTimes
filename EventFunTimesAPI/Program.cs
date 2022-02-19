using Microsoft.EntityFrameworkCore;
using EventFunTimesAPI.Services.Interfaces;
using Microsoft.OpenApi.Models;
using EventFunTimesAPI.Services;
using EventFunTimesAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers()
           .AddNewtonsoftJson(x => x.SerializerSettings
           .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EventFunTimes", Version = "v1" });
});

builder.Services.AddScoped<IEventHostService, EventService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IOpeninghoursService, OpeninghoursService>();
builder.Services.AddScoped<ISeedService, SeedService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventFunTimes v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
