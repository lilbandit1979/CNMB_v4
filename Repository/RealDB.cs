using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RealDB : IRepository
    {
     
        CNMBContext _db = default!;
         
        public RealDB(CNMBContext db)
        {
            this._db=db;
        }
        ~RealDB() //destructor
        {
            if (_db != null) _db.Dispose();
        }

        public void AddSchool(School school)
        {
            _db.School.Add(school);
            _db.SaveChanges();

        }

        public void AddTeacher(Teacher teacher)
        {
            _db.Teacher.Add(teacher);
            _db.SaveChanges();
        }

        public void DeleteSchool(int id)
        {
            var found = _db.School.Find(id);
            if (found != null)
            {
                _db.School.Remove(found);
                _db.SaveChanges();
            }
            throw new Exception("School not found");
        }

        public void DeleteTeacher(int id)
        {
            var found = _db.Teacher.Find(id);
            if (found != null)
            {
                _db.Teacher.Remove(found);
                _db.SaveChanges();
            }
            throw new Exception("Teacher not found");
        }

        public IEnumerable<School> GetAllSchools()
        {
            return _db.School.ToList();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
           return _db.Teacher.ToList();
        }

        public School GetSchoolById(int id)
        {
            var found = _db.School.Find(id);
            {
                if (found != null)
                {
                    return found;
                }
                throw new Exception("School not found");
            }
        }

        public Teacher GetTeacherById(int id)
        {
            var found = _db.Teacher.Find(id);
            if(found!=null)
            {
                return found;
            }
            throw new Exception("Teacher not found");
            
        }

        public void UpdateSchool(School school)
        {
            var found = _db.School.Find(school.SchoolId);
            if(found!=null)
            {
                found.SchoolName=school.SchoolName;
                found.SchoolPhone=school.SchoolPhone;
                found.SchoolEircode = school.SchoolEircode;
                found.SchoolAddress=school.SchoolAddress;
                
                _db.School.Update(found); //check this ************
            }
            
        }

        public void UpdateTeacher(Teacher teacher)
        {
            var found = _db.Teacher.Find(teacher.TeacherId);
            if (found != null)
            {
                found.FName = teacher.FName;
                found.SName = teacher.SName;
                found.TeacherPhone = teacher.TeacherPhone;
                found.IsMainRep = teacher.IsMainRep;
                _db.Teacher.Update(found);//check this ************ --> should it be found.TeacherId
            }
        }
    }
}


//find teacher/school/team by string var user = context.Users.Find("johndoe1987");

