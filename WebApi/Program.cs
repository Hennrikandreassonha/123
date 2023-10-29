global using GYMAPP.Domain.Workouts;
global using GYMAPP.Domain.Exercises;
global using GYMAPP.Domain.DbObjects;
global using WebApi.Domain.Exercises;
global using WebApi.Infrastructure.Repository.WorkoutRepository;


using System;
using WebApi.Infrastructure.Repository.Database;
using Microsoft.EntityFrameworkCore;
using WebApi.Infrastructure.Repository.WorkoutRepository;
using WebApi.Infrastructure.Repository.ExerciseRepository;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<GymAppContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

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
