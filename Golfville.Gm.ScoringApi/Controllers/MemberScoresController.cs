using Microsoft.AspNetCore.Mvc;

namespace Golfville.Gm.ScoringApi.Controllers
{
    [ApiController]    
    public class MemberScoresController : ControllerBase
    {       
        private readonly ILogger<MemberScoresController> _logger;

        public MemberScoresController(ILogger<MemberScoresController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/member/{memberId}/scores", Name = "GetMemberScores")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable
                .Range(1, 5)
                .Select(
                    index =>
                        new WeatherForecast
                        {
                            Date = DateTime.Now.AddDays(index),
                            TemperatureC = Random.Shared.Next(-20, 55),
                            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                        }
                )
                .ToArray();
        }
    }
}
