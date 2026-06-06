using BussinesLayer.Abstract;
using BussinesLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.EntityFramework;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PremierLigApi.Mapping;
using PremierLigApi.Middlewares;
using PremierLigApi.Validators.TeamValidators;

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

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateTeamDtoValidator>();

builder.Services.AddScoped<IStandingService, StandingManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
