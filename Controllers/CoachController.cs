using DSCC.CW1._14039.Model;
using DSCC.CW1._14039.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace DSCC.CW1._14039.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : Controller
    {
        private readonly ICoachRepository _coachRepository;

        public CoachController(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }

        // GET: api/Coach
        [HttpGet]
        public IActionResult Get()
        {
            var coaches = _coachRepository.GetCoaches();
            return Ok(coaches);
        }

        // GET: api/Coach/5
        [HttpGet("{id}", Name = "GetCoach")]
        public IActionResult Get(int id)
        {
            var coach = _coachRepository.GetCoachById(id);
            if (coach == null)
            {
                return NotFound();
            }
            return Ok(coach);
        }

        // POST: api/Coach
        [HttpPost]
        public IActionResult Post([FromBody] Coach coach)
        {
            if (coach == null)
            {
                return BadRequest();
            }

            using (var scope = new TransactionScope())
            {
                _coachRepository.InsertCoach(coach);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = coach.CoachId }, coach);
            }
        }

        // PUT: api/Coach/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Coach coach)
        {
            if (coach == null || coach.CoachId != id)
            {
                return BadRequest();
            }

            using (var scope = new TransactionScope())
            {
                _coachRepository.UpdateCoach(coach);
                scope.Complete();
                return Ok();
            }
        }

        // DELETE: api/Coach/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCoach = _coachRepository.GetCoachById(id);
            if (existingCoach == null)
            {
                return NotFound();
            }

            _coachRepository.DeleteCoach(id);
            return Ok();
        }
    }
}
