using Golfville.Gm.Scoring.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Golfville.Gm.Scoring.Api.Controllers
{    
    [ApiController]
    public class HandicapController : ControllerBase
    {
        private readonly IHandicapService _handicapService;
        private readonly IMemberScoreRepository _memberScoreRepository;

        public HandicapController(IHandicapService handicapService, IMemberScoreRepository memberScoreRepository)
        {
            _handicapService = handicapService;
            _memberScoreRepository = memberScoreRepository;
        }

        [HttpGet("member/{memberId}/handicap", Name = "GetHandicapForMember")]
        public async Task<IActionResult> GetForMemberAsync(int memberId)
        {
            // A minimum of 3 scores are required
            var scores = await _memberScoreRepository.GetScoresAsync(memberId, 3);
            if (scores.Count < 3)
                return NotFound();

            var handicap = await _handicapService.Calculate(memberId);
            return Ok(handicap);
        }
    }
}
