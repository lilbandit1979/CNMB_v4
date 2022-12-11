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
        //private readonly IPrescriptionRepository _prescriptionRepository;
        //private readonly IMapper _mapper;
        //public PrescriptionController(IPrescriptionRepository prescriptionRepository, IMapper mapper)
        //{
        //    _prescriptionRepository = prescriptionRepository;
        //    _mapper = mapper;
        //}
        //// GET: api/<PrescrptionController>
        //[HttpGet]
        //public ActionResult<IEnumerable<PrescriptionReadDto>> Get()
        //{
        //    var prescriptions = _prescriptionRepository.GetAll();

        //    var prescriptionDto = _mapper.Map<IEnumerable<PrescriptionReadDto>>(prescriptions);

        //    if (prescriptions == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(prescriptionDto);

        //}

        //Mine below:
        private readonly IRepository _context = default!;  //Check this on monday night
        //private readonly IRepository _repo;

        //add in IRepository stuff here: See below
        //private readonly IRepository _db;

      
        public SchoolsController(IRepository context) //Check this on Monday night--should it be IRepository?
        {
            this._context = context;
        }

        // GET: api/Schools
        [HttpGet]
        public ActionResult<IEnumerable<School>> GetSchool()
        {
            //return await _context.School.ToListAsync();
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
            //var found = _context.School.Find(id);
            var found = _context.GetSchoolById(id);
            if (found != null)
            {
                _context.UpdateSchool(found);
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
        public ActionResult<School> PostSchool(School school)
        {
            //_context.School.Add(school);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetSchool", new { id = school.SchoolId }, school);
            _context.AddSchool(school);
            return Ok(school.SchoolId); //check if it can just be Ok();
        }

        //// DELETE: api/Schools/5 
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteSchool(int id)
        //{
        //    //var school = await _context.School.FindAsync(id);
        //    var school = _context.GetSchoolById(id);
        //    if (school != null)
        //    {
        //        _context.DeleteSchool(school);
        //    }

        //    //_context.School.Remove(school);
        //    //await _context.SaveChangesAsync();
            
        //    return NotFound();
        //    //return NoContent();
        //}

        //private bool SchoolExists(int id)
        //{
        //    return _context.School.Any(e => e.SchoolId == id);
        //}
    }
}
