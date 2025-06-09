using DSCC.CW1._14039.Model;

namespace DSCC.CW1._14039.Repository
{
    public interface ITeamRepository
    {
        void InsertTeam(Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(int teamId);
        Team GetTeamById(int id);
        IEnumerable<Team> GetTeams();
    }

}
