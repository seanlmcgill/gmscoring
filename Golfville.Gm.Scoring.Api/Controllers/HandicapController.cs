using Golfville.Gm.Scoring.Data.Repositories;
using Golfville.Gm.Scoring.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Golfville.Gm.Scoring.Api.Controllers
{
    [ApiController]
    public class HandicapController : ControllerBase
    {
        private readonly IHandicapService _handicapService;
        
        public HandicapController(IHandicapService handicapService)
        {
            _handicapService = handicapService;            
        }

        [HttpGet("member/{memberId}/handicap", Name = "GetHandicapForMember")]
        public async Task<IActionResult> GetForMemberAsync(int memberId)
        {            
            var handicap = await _handicapService.Calculate(memberId);
            return Ok(handicap);
        }
    }
}
