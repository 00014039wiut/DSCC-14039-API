using DSCC.CW1._14039.DbContexts;
using DSCC.CW1._14039.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._14039.Repository
{
    public class CoachRepository : ICoachRepository
    {
        private readonly TeamDbContext _dbContext;

        public CoachRepository(TeamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertCoach(Coach coach)
        {
            _dbContext.Coaches.Add(coach);
            Save();
        }

        public void UpdateCoach(Coach coach)
        {
            _dbContext.Entry(coach).State = EntityState.Modified;
            Save();
        }

        public void DeleteCoach(int coachId)
        {
            var coach = _dbContext.Coaches.Find(coachId);
            if (coach != null)
            {
                _dbContext.Coaches.Remove(coach);
                Save();
            }
        }

        public Coach GetCoachById(int id)
        {
            return _dbContext.Coaches.Find(id);
        }

        public IEnumerable<Coach> GetCoaches()
        {
            return _dbContext.Coaches.ToList();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
