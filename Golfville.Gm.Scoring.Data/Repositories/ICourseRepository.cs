using Golfville.Gm.Scoring.Data.Entities;

namespace Golfville.Gm.Scoring.Data.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCoursesAsync(List<int> courseIds);
        Task<List<Course>> GetCoursesAsync(string stateCode = "");
    }
}
