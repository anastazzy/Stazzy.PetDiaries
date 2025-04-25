using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MyPets.Application.Contracts;
using MyPets.Application.Dtos;
using MyPets.Application.Services;
using MyPets.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyPetsDbContext>(x =>
    x.UseNpgsql(builder.Configuration.GetConnectionString("Postgre")));

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
//     .AddJsonOptions(options =>
// {
//     var converters = options.JsonSerializerOptions.Converters;
//     converters.Add(new JsonStringEnumConverter());
// });

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// builder.Services.AddOpenApi();

// builder.Services.AddEndpointsApiExplorer();
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