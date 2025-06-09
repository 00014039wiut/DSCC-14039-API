using DSCC.CW1._14039.DbContexts;
using DSCC.CW1._14039.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._14039.Repository
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TeamDbContext _dbContext;

        public TeamRepository(TeamDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InsertTeam(Team team)
        {
            _dbContext.Teams.Add(team);
            Save();
        }

        public void UpdateTeam(Team team)
        {
            _dbContext.Entry(team).State = EntityState.Modified;
            Save();
        }

        public void DeleteTeam(int teamId)
        {
            var team = _dbContext.Teams.Find(teamId);
            if (team != null)
            {
                _dbContext.Teams.Remove(team);
                Save();
            }
        }

        public Team GetTeamById(int id)
        {
            var team = _dbContext.Teams.Find(id);
            if (team == null)
            {
                // Optional: throw an exception or return null
                return null;
            }

            _dbContext.Entry(team).Reference(t => t.TeamCoach).Load();
            return team;
        }


        public IEnumerable<Team> GetTeams()
        {
            return _dbContext.Teams.Include(t => t.TeamCoach).ToList();
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
