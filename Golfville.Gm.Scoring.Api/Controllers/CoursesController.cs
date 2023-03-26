using Golfville.Gm.Scoring.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Golfville.Gm.Scoring.Api.Controllers
{
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;

        public CoursesController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet("api/courses", Name = "GetCourses")]
        public async Task<IActionResult> Get(string stateCode = "")
        {
            var courses = await _courseRepository.GetCoursesAsync(stateCode);
            return Ok(courses);
        }
    }
}
