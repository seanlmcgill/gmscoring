using Golfville.Gm.Scoring.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private GmDbContext _gmDbContext;

        public CourseRepository(GmDbContext scoringDbContext)
        {
            _gmDbContext = scoringDbContext;
        }

        public async Task<List<Course>> GetCoursesAsync(string stateCode)
        {
            var query = _gmDbContext.Courses.Include("TeeBoxes").AsQueryable();
            if (!string.IsNullOrWhiteSpace(stateCode))
                query = query.Where(x => x.StateCode == stateCode);

            return await query.ToListAsync();
        }

        public async Task<List<Course>> GetCoursesAsync(List<int> courseIds)
        {
            return await _gmDbContext.Courses
                .Where(x => courseIds.Contains(x.CourseId))
                .ToListAsync();
        }
    }
}
