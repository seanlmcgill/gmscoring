using Golfville.Gm.Scoring.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Golfville.Gm.Scoring.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ILogger<CoursesController> _logger;
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ILogger<CoursesController> logger, ICourseRepository courseRepository)
        {
            _logger = logger;
            _courseRepository = courseRepository;
        }

        [HttpGet("/courses", Name = "GetCourses")]
        public async Task<IActionResult> Get(string stateCode = "")
        {
            var courses = await _courseRepository.GetCoursesAsync(stateCode);
            return Ok(courses);
        }
    }
}
