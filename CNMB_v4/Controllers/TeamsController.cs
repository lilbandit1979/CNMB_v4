using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Models;
using Repository;

namespace CNMB_v4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly IRepository _context = default!;
        //add in IRepository stuff here: See below
        //private readonly IRepository _db;

        //public StudentMockDBController(IRepository db) //constructor
        //{
        //    _db = db;
        //}

        public TeamsController(IRepository context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public ActionResult<IEnumerable<Team>> GetTeams()
        {
            return _context.GetAllTeams().ToList();
        }

        // GET: api/Teams/5
        [HttpGet("{id}")]
        public ActionResult<Team> GetTeam(int id)
        {
            var team = _context.GetTeamById(id);

            if (team != null)
            {
                return team;
            }

            return NotFound();
        }

        // PUT: api/Teams/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult<Team> PutTeam(int id, Team team)
        {
            if (id != team.TeamId)
            {
                return BadRequest();
            }

            var found = _context.GetSchoolById(id);
            if(found!=null)
            {
                _context.UpdateTeam(team);
                return Ok(found);
            }
            return NotFound();
        }

        //// POST: api/Teams
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Team> PostTeam(Team team)
        {
            _context.AddTeam(team);
            return CreatedAtAction("GetTeam", new { id = team.TeamId }, team);
        }

        //// DELETE: api/Teams/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTeam(int id)
        //{
        //    var team = await _context.Team.FindAsync(id);
        //    if (team == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Team.Remove(team);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TeamExists(int id)
        //{
        //    return _context.Team.Any(e => e.TeamId == id);
        //}
    }
}
