global using GYMAPP.Domain.Workouts;
global using GYMAPP.Domain.Exercises;
global using GYMAPP.Domain.DbObjects;
global using WebApi.Domain.Exercises;
global using WebApi.Infrastructure.Repository.WorkoutRepository;
global using WebApi.Infrastructure.Repository.ExerciseRepository;
global using WebApi.Domain.Auth;
global using WebApi.Domain.Login;
global using WebApi.Infrastructure.Repository.Database;

using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.UserRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GymAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


builder.Services.AddControllers();
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
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
