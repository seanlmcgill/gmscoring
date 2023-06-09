using Golfville.Gm.Scoring.Data.Entities;
using Golfville.Gm.Scoring.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Golfville.Gm.ScoringApi.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class MemberScoresController : ControllerBase
    {
        private readonly IMemberScoreRepository _memberScoreRepository;

        public MemberScoresController(IMemberScoreRepository memberScoreRepository)
        {
            _memberScoreRepository = memberScoreRepository;
        }

        [ApiVersion("1.0")]
        [HttpGet("member/{memberId}/memberscores", Name = "GetMemberScores")]
        public async Task<IActionResult> Get(int memberId, int top = 20)
        {
            var scores = await _memberScoreRepository.GetRecentScores(memberId, top);
            return Ok(scores);
        }

        [ApiVersion("1.0")]
        [HttpGet("memberscores/{year}", Name = "GetAllMemberScores")]
        public async Task<IActionResult> GetAllAsync(int year)
        {
            var scores = await _memberScoreRepository.GetAllForYearAsync(year);
            return Ok(scores);
        }

        [ApiVersion("1.0")]
        [HttpPost("memberscores", Name = "AddMemberScore")]
        public async Task<MemberScore> PostAsync(MemberScore score)
        {
            var newScore = await _memberScoreRepository.AddScoreAsync(score);
            return newScore;
        }
    }
}
