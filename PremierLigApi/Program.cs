using BussinesLayer.Abstract;
using BussinesLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using PremierLigApi.Mapping;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<PremierLeagueContext>();

builder.Services.AddScoped<ITeamDal, EfTeamDal>();
builder.Services.AddScoped<ITeamService, TeamManager>();

builder.Services.AddScoped<IMatchDal, EfMatchDal>();
builder.Services.AddScoped<IMatchService, MatchManager>();

builder.Services.AddScoped<IMatchEventDal, EfMatchEventDal>();
builder.Services.AddScoped<IMatchEventService, MatchEventManager>();

builder.Services.AddScoped<IMatchStatisticDal, EfMatchStatisticDal>();
builder.Services.AddScoped<IMatchStatisticService, MatchStatisticManager>();

builder.Services.AddScoped<IStandingService, StandingManager>();

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
