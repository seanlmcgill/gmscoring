using Golfville.Gm.Scoring.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Golfville.Gm.Scoring.Api.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class HandicapController : ControllerBase
    {
        private readonly IHandicapService _handicapService;

        public HandicapController(IHandicapService handicapService)
        {
            _handicapService = handicapService;
        }

        [ApiVersion("1.0")]
        [HttpGet("member/{memberId}/handicap", Name = "GetHandicapForMember")]
        public async Task<IActionResult> GetForMemberAsync(int memberId)
        {
            var handicap = await _handicapService.CalculateAsync(memberId);
            return Ok(handicap);
        }
    }
}
