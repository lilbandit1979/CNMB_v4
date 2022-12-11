using Microsoft.EntityFrameworkCore;
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
     
        private readonly CNMBContext _context;
         
        public RealDB(CNMBContext context)
        {
            _context=context;
        }
        //~RealDB() //destructor //Check if needed ***********
        //{
        //    if (context != null) context.Dispose();
        //}

        public void AddSchool(School school)
        {
            _context.School.Add(school);
            _context.SaveChanges();

        }

        public void AddTeacher(Teacher teacher)
        {
            _context.Teacher.Add(teacher);
            _context.SaveChanges();
        }

        public void DeleteSchool(int id)
        {
            var found = _context.School.Find(id);
            if (found != null)
            {
                _context.School.Remove(found);
                _context.SaveChanges();
            }
            throw new Exception("School not found");
        }

        public void DeleteTeacher(int id)
        {
            var found = _context.Teacher.Find(id);
            if (found != null)
            {
                _context.Teacher.Remove(found);
                _context.SaveChanges();
            }
            throw new Exception("Teacher not found");
        }

        public IEnumerable<School> GetAllSchools()
        {
            return _context.School.ToList();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
           return _context.Teacher.ToList();
        }

        public School GetSchoolById(int id)
        {
            var found = _context.School.Find(id);
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
            var found = _context.Teacher.Find(id);
            if(found!=null)
            {
                return found;
            }
            throw new Exception("Teacher not found");
            
        }

        public void UpdateSchool(School school)
        {
            var found = _context.School.Find(school.SchoolId);
            if(found!=null)
            {
                found.SchoolName=school.SchoolName;
                found.SchoolPhone=school.SchoolPhone;
                found.SchoolEircode = school.SchoolEircode;
                found.SchoolAddress=school.SchoolAddress;
                
                _context.School.Update(found); //check this ************
            }
            
        }

        public void UpdateTeacher(Teacher teacher)
        {
            var found = _context.Teacher.Find(teacher.TeacherId);
            if (found != null)
            {
                found.FName = teacher.FName;
                found.SName = teacher.SName;
                found.TeacherPhone = teacher.TeacherPhone;
                found.IsMainRep = teacher.IsMainRep;
                _context.Teacher.Update(found);//check this ************ --> should it be found.TeacherId
            }
        }
    }
}


//find teacher/school/team by string var user = _context.Users.Find("johndoe1987");

