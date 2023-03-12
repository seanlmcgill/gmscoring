using Golfville.Gm.Scoring.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private IScoringDbContext _scoringDbContext;

        public CourseRepository(IScoringDbContext scoringDbContext)
        {
            _scoringDbContext = scoringDbContext;
        }

        public async Task<List<Course>> GetCoursesAsync(List<int> courseIds)
        {
            return await _scoringDbContext.Courses
                .Where(x => courseIds.Contains(x.Id))
                .ToListAsync();
        }
    }
}
