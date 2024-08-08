using ACME.School.Application.Services.Impl;
using ACME.School.Application.Services.Interfaces;
using ACME.School.Application.Validators;
using ACME.School.Domain.Repositories;
using ACME.School.Infrastructure;
using ACME.School.Infrastructure.Gateways;
using ACME.School.Infrastructure.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ConfigureServices(builder);

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

static void ConfigureServices(IHostApplicationBuilder builder)
{
    builder.Services.AddDbContext<SchoolContext>(options =>
        options.UseInMemoryDatabase("SchoolDatabase"));

    builder.Services.AddScoped<IStudentRepository, StudentRepository>();
    builder.Services.AddScoped<ICourseRepository, CourseRepository>();
    builder.Services.AddScoped<IStudentService, StudentService>();
    builder.Services.AddScoped<ICourseService, CourseService>();
    builder.Services.AddScoped<IPaymentGateway, PaymentGateway>();
    builder.Services.AddScoped<IRegistrationService, RegistrationService>();

    builder.Services.AddValidatorsFromAssemblyContaining<StudentValidator>();
    builder.Services.AddValidatorsFromAssemblyContaining<CourseValidator>();
    builder.Services.AddFluentValidationAutoValidation();
    builder.Services.AddFluentValidationClientsideAdapters();
}

