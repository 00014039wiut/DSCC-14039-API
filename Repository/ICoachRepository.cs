using DSCC.CW1._14039.Model;

namespace DSCC.CW1._14039.Repository
{
    public interface ICoachRepository
    {
        void InsertCoach(Coach coach);
        void UpdateCoach(Coach coach);
        void DeleteCoach(int coachId);
        Coach GetCoachById(int id);
        IEnumerable<Coach> GetCoaches();
    }

}
