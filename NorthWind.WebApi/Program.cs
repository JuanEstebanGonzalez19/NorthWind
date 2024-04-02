using NorthWind.IoC;
using Microsoft.Extensions.Configuration;
using NorthWind.Entities.Exceptions;
using NorthWind.WebExceptionsPresenter;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configurar IConfiguration
builder.Configuration.AddJsonFile("appsettings.json");

// Add services to the container.
builder.Services.AddControllers(options =>
            options.Filters.Add(new ApiExceptionFilterAttribute(
                new Dictionary<Type, IExceptionHandler>
                {
                    {typeof(GeneralException), new GeneralExceptionHandler()},
                    {typeof(ValidationException), new ValidationExceptionHandler()},
                }
            )));
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
// Agregar servicios personalizados de NorthWind
builder.Services.AddNorthWindServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();