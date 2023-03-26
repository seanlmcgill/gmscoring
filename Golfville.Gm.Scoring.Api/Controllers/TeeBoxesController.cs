using Golfville.Gm.Scoring.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Golfville.Gm.Scoring.Api.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class TeeBoxesController : ControllerBase
    {
        private readonly ITeeBoxRepository _teeBoxRepository;

        public TeeBoxesController(ITeeBoxRepository teeBoxRepository)
        {
            _teeBoxRepository = teeBoxRepository;
        }

        [ApiVersion("1.0")]
        [HttpGet("course/{courseId}/teeboxes", Name = "GetTeeBoxesForCourse")]
        public async Task<IActionResult> GetForCourseAsync(int courseId)
        {
            return null;
        }
    }
}
