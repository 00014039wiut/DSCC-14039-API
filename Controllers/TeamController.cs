using DSCC.CW1._14039.Model;
using DSCC.CW1._14039.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace DSCC.CW1._14039.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly ITeamRepository _teamRepository;

        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        // GET: api/Team
        [HttpGet]
        public IActionResult Get()
        {
            var teams = _teamRepository.GetTeams();
            return Ok(teams);
        }

        // GET: api/Team/5
        [HttpGet("{id}", Name = "GetTeam")]
        public IActionResult Get(int id)
        {
            var team = _teamRepository.GetTeamById(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }

        // POST: api/Team
        [HttpPost]
        public IActionResult Post([FromBody] Team team)
        {
            if (team == null)
            {
                return BadRequest();
            }

            using (var scope = new TransactionScope())
            {
                _teamRepository.InsertTeam(team);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = team.TeamId }, team);
            }
        }

        // PUT: api/Team/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Team team)
        {
            if (team == null || team.TeamId != id)
            {
                return BadRequest();
            }

            using (var scope = new TransactionScope())
            {
                _teamRepository.UpdateTeam(team);
                scope.Complete();
                return Ok();
            }
        }

        // DELETE: api/Team/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingTeam = _teamRepository.GetTeamById(id);
            if (existingTeam == null)
            {
                return NotFound();
            }

            _teamRepository.DeleteTeam(id);
            return Ok();
        }
    }
}
