using Microsoft.AspNetCore.Mvc;
using Golfville.Gm.Scoring.Data.Entities;
using Golfville.Gm.Scoring.Data.Repositories;

namespace Golfville.Gm.ScoringApi.Controllers
{
    [ApiController]    
    public class MemberScoresController : ControllerBase
    {       
        private readonly ILogger<MemberScoresController> _logger;
        private readonly IMemberScoreRepository _memberScoreRepository;

        public MemberScoresController(ILogger<MemberScoresController> logger, IMemberScoreRepository memberScoreRepository)
        {
            _logger = logger;
            _memberScoreRepository = memberScoreRepository;
        }

        [HttpGet("/member/{memberId}/scores", Name = "GetMemberScores")]
        public async Task<IActionResult> Get(int memberId, int top = 20)
        {
            var scores = await _memberScoreRepository.GetRecentScores(memberId, top);
            return Ok(scores);
        }

        [HttpGet("/memberscores/{year}", Name = "GetAllMemberScores")]
        public async Task<IActionResult> GetAllAsync(int year)
        {
            var scores = await _memberScoreRepository.GetAllForYearAsync(year);
            return Ok(scores);
        }

        [HttpPost("/memberscores", Name = "AddMemberScore")]
        public async Task<MemberScore> PostAsync(MemberScore score)
        {
            var newScore = await _memberScoreRepository.AddScoreAsync(score);            
            return newScore;
        }
    }
}
