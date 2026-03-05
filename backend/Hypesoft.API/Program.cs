using FluentValidation;
using Hypesoft.Application.Commands.Products;
using Hypesoft.Application.Validators;
using Hypesoft.Domain.Repositories;
using Hypesoft.Infrastructure.Configurations;
using Hypesoft.Infrastructure.Data;
using Hypesoft.Infrastructure.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(CreateProductCommand).Assembly));

builder.Services.AddValidatorsFromAssembly(typeof(CreateProductValidator).Assembly);

builder.Services.Configure<MongoOptions>(
    builder.Configuration.GetSection("Mongo")
);

builder.Services.AddSingleton<MongoContext>();

builder.Services.AddScoped<ICategoryRepository, MongoCategoryRepository>();
builder.Services.AddScoped<IProductRepository, MongoProductRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();