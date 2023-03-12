using Golfville.Gm.Scoring.Data.Entities;
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

var scoringDbName = configuration.GetValue<string>("ScoringDbName");
logger.Information("Configured mock in-memory database name for testing is: {scoringDbName}", scoringDbName);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoringRepositoryServices(scoringDbName);

var app = builder.Build();

logger.Information("Seeding test data into in memory database: {scoringDbName}", scoringDbName);
using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetService<ScoringDbContext>();
    dbContext?.Database.EnsureCreated();
}

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
