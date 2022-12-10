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
    public class SchoolsController : ControllerBase
    {
        private readonly CNMBContext _context;  //Check this on monday night
        //private readonly IRepository _context;

        //add in IRepository stuff here: See below
        //private readonly IRepository _db;

      
        public SchoolsController(CNMBContext db)
        {
            _context = db;
        }

        // GET: api/Schools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<School>>> GetSchool()
        {
            return await _context.School.ToListAsync();
        }

        // GET: api/Schools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            var school = await _context.School.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return school;
        }

        // PUT: api/Schools/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutSchool(int id, School school) //change this in RealDB class?
        //{

        //    if (id != school.SchoolId)
        //    {

        //        return BadRequest();
        //    }

        //    _context.Entry(school).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SchoolExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        [HttpPut("{id}")] // working here -------> editing template
        public ActionResult<School> PutSchool(School school, int id)
        {
            if (id != school.SchoolId)
            {
                return BadRequest();
            }

            //_db.Entry(studentExam).State = EntityState.Modified;
            var found = _context.GetSchool(id);
            if (found != null)
            {
                _db.EditStudentExam(studentExam);
                return found;
            }
            return NotFound();
            //if(found == null)
            //{
            //    return NotFound();
            //}
            //_db.EditStudentExam(studentExam); //pass in the one I want to edit
            //return found;
            //_db.EditStudentExam(found);
            //return Ok(); //not editing






            //var found = _db.GetStudentExam(id);
            //_db.EditStudentExam(found);
            //return Ok(); //not sure about this!!  
        }


        // POST: api/Schools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<School>> PostSchool(School school)
        {
            _context.School.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSchool", new { id = school.SchoolId }, school);
        }

        // DELETE: api/Schools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _context.School.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            _context.School.Remove(school);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolExists(int id)
        {
            return _context.School.Any(e => e.SchoolId == id);
        }
    }
}
