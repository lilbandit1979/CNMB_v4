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
    public class TeachersController : ControllerBase
    {
        private readonly IRepository _context = default!;
        //add in IRepository stuff here: See below
        //private readonly IRepository _db;

        //public StudentMockDBController(IRepository db) //constructor
        //{
        //    _db = db;
        //} pray!!

        public TeachersController(IRepository context)
        {
            this._context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public  ActionResult<IEnumerable<Teacher>> GetTeacher()
        {
            return _context.GetAllTeachers().ToList();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public ActionResult<Teacher> GetTeacher(int id)
        {
            var teacher = _context.GetTeacherById(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return teacher;
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutTeacher(int id, Teacher teacher)
        {
            if (id != teacher.TeacherId)
            {
                return BadRequest();
            }
            var found = _context.GetTeacherById(id);
            if(found!=null)
            {
                _context.UpdateTeacher(teacher);
            }
            return Ok();
        }

        //[HttpPut("{id}")] // works ---Edit school only
        //public ActionResult<School> PutSchool(School school, int id)
        //{
        //    if (id != school.SchoolId)
        //    {
        //        return BadRequest();
        //    }
        //    var found = _context.GetSchoolById(id);
        //    if (found != null)
        //    {
        //        _context.UpdateSchool(found);
        //    }
        //    // _context.UpdateSchool(school);
        //    return Ok();
        //}

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost] //works --teacher only
        public ActionResult<Teacher> PostTeacher(Teacher teacher)
        {
            _context.AddTeacher(teacher);
            //check this below --might give a better return in Swagger than Ok();
            return CreatedAtAction("GetTeacher", new { id = teacher.TeacherId }, teacher);
        }

        //// DELETE: api/Teachers/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTeacher(int id)
        //{
        //    var teacher = await _context.Teacher.FindAsync(id);
        //    if (teacher == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Teacher.Remove(teacher);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool TeacherExists(int id)
        //{
        //    return _context.Teacher.Any(e => e.TeacherId == id);
        //}
    }
}
