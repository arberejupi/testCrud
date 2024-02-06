using AppointEase.Application.AppointEase.Application.Filters;
using AppointEase.Application.AppointEase.Application.Interface;
using AppointEase.Application.AppointEase.Application.Mapper;
using AppointEase.Application.AppointEase.Application.Service;
using AppointEase.Application.AppointEase.Application.Validator;
using AppointEase.Domain.AppointEase.Domain.Models;
using AppointEase.Infrastructure.AppointEase.Infrastructure.Data;
using AppointEase.Infrastructure.AppointEase.Infrastructure.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddControllers(options =>
{
    options.Filters.Add<GlobalExceptionFilter>();
});

// Set the default culture to invariant
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

builder.Services.AddTransient<IValidator<PersonDto>, PersonDtoValidator>();

builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddAutoMapper(typeof(YourMappingProfile));

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IValidator<PersonDto>, PersonDtoValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
