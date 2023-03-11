using Golfville.Gm.Scoring.Data.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = new ConfigurationBuilder()
    .AddCommandLine(Environment.GetCommandLineArgs())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
var logger = Log.ForContext<Program>();

var scoringDbConnectionString = configuration.GetConnectionString("gmdb");
var scoringDbName = configuration.GetValue<string>("gmdbname");

logger.Information("Connecting to database {scoringDbName} with connection string {scoringDbConnectionString}", scoringDbName, scoringDbConnectionString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoringRepositoryServices(scoringDbConnectionString, scoringDbName);

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
