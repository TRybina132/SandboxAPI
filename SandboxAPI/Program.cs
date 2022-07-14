using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using SandboxAPI.Configuration;
using System.Text.Json.Serialization;
using WebAPI.Controllers;
using WebAPI.Mappers.MappersConfig;

string allowedOrigins = "frontend";

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();
builder.Services.ConfigureMappers();

builder.Services.AddDbContext<SandboxContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMvc()
    .AddApplicationPart(typeof(DeliveryController).Assembly)
    .AddControllersAsServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:4200");
        policy.WithHeaders("*");
        policy.WithMethods("*");
    });
});

builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
}).AddJsonOptions(jsonOptions =>
                jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.ConfigureMiddleware();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowedOrigins);
app.MapControllers();

app.Run();
