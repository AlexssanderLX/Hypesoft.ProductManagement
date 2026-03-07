using FluentValidation;
using Hypesoft.Application.Commands.Products;
using Hypesoft.Application.Validators;
using Hypesoft.Domain.Repositories;
using Hypesoft.Infrastructure.Configurations;
using Hypesoft.Infrastructure.Data;
using Hypesoft.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);


// SERILOG
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();


// CONTROLLERS
builder.Services.AddControllers();


// SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// MEDIATR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly));


// FLUENT VALIDATION
builder.Services.AddValidatorsFromAssembly(typeof(CreateProductValidator).Assembly);


// MONGO CONFIG
builder.Services.Configure<MongoOptions>(
    builder.Configuration.GetSection("Mongo")
);

builder.Services.AddSingleton<MongoContext>();


// REPOSITORIES
builder.Services.AddScoped<ICategoryRepository, MongoCategoryRepository>();
builder.Services.AddScoped<IProductRepository, MongoProductRepository>();


// RATE LIMIT
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("api", opt =>
    {
        opt.PermitLimit = 100;
        opt.Window = TimeSpan.FromMinutes(1);
    });
});


var app = builder.Build();


// SECURITY HEADERS
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");

    await next();
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// RATE LIMIT
app.UseRateLimiter();


app.UseHttpsRedirection();

app.UseCors("AllowFrontend");


app.MapControllers();



app.Run();