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
        public IEnumerable<MemberScore> Get()
        {
            return new List<MemberScore>();    
        }

        [HttpPost("/memberscore", Name = "AddMemberScore")]
        public async Task<MemberScore> PostAsync(MemberScore score)
        {
            var newScore = await _memberScoreRepository.AddScoreAsync(score);            
            return newScore;
        }
    }
}
