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
        private readonly IRepository _context = default!; 
        //private readonly IRepository _repo;

        //add in IRepository stuff here: See below
        //private readonly IRepository _db;

      
        public SchoolsController(IRepository context) 
        {
            this._context = context;
        }

        // GET: api/Schools
        [HttpGet]
        public ActionResult<IEnumerable<School>> GetSchool()
        { 
            return _context.GetAllSchools().ToList();
           
        }

        // GET: api/Schools/5
        [HttpGet("{id}")]
        public  ActionResult<School> GetSchool(int id)
        {
            var school = _context.GetSchoolById(id);

            if (school != null)
            {
                return Ok(school);
            }

            return NotFound();
        }

        [HttpPut("{id}")] // works ---Edit school only
        public ActionResult<School> PutSchool(int id, School school)
        {
            if (id != school.SchoolId)
            {
                return BadRequest();
            }
            var found = _context.GetSchoolById(id);
            if (found != null)
            {
                _context.UpdateSchool(school);
                return Ok(found);
            }
            return NotFound();
            
            
        }


        // POST: api/Schools
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<School> PostSchool(School school)
        {
            if(school.SchoolId>0)
            {
                _context.UpdateSchool(school);
                return Ok(school);
            }
            _context.AddSchool(school);
            return Ok(school); 
        }

       
        // DELETE: api/Schools/5 
        [HttpDelete("{id}")]
        public ActionResult DeleteSchool(int id)
        {
            
            var school = _context.GetSchoolById(id);
            if (school != null)
            {
                _context.DeleteSchool(school.SchoolId);
                return Ok();
            }
            return NotFound();
        }

        //private bool SchoolExists(int id)
        //{
        //    return _context.School.Any(e => e.SchoolId == id);
        //}
    }
}
