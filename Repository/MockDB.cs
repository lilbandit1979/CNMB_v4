using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MockDB : IRepository
    {
        public static List<Teacher> _teachers = new List<Teacher>()
        {
            new Teacher {TeacherId = 1, FName="Fiona",SName="O Brien",TeacherPhone="0876451432",IsMainRep=false},
            new Teacher {TeacherId = 2, FName="Saoirse",SName="Barry",TeacherPhone="0838764018",IsMainRep=false},
            new Teacher {TeacherId = 3, FName="Stephen",SName="Roche",TeacherPhone="0856156432",IsMainRep=true},
            new Teacher {TeacherId = 4, FName="Karl",SName="Benz",TeacherPhone="0868738010",IsMainRep=false}
        };

        public static List<School> _schools = new List<School>()
        {
            new School {SchoolID=1,SchoolName="Conleths",SchoolPhone="045431179",SchoolAddress="Newbridge",SchoolEircode="W12F659"},
            new School {SchoolID=2,SchoolName="Patricians",SchoolPhone="045238867",SchoolAddress="Newbridge",SchoolEircode="W12F658"},
            new School {SchoolID=3,SchoolName="Corbans",SchoolPhone="045651175",SchoolAddress="Naas",SchoolEircode="Z14F250"},
            new School {SchoolID=4,SchoolName="Convent",SchoolPhone="045318860",SchoolAddress="Leixlip",SchoolEircode="E56F195"}
        };
        public void AddSchool(School school)
        {
            _schools.Add(school);
            
        }

        public void AddTeacher(Teacher teacher)
        {
            _teachers.Add(teacher);
            
        }

        public void DeleteSchool(int id)
        {
            var found = _schools.FirstOrDefault(x => x.SchoolId == id);
            if (found != null)
            {
                _schools.Remove(found);
            }
        }

        public void DeleteTeacher(int id)
        {
            var found = _teachers.FirstOrDefault(x => x.TeacherId == id);
            if (found != null)
            {
                _teachers.Remove(found);
            }
            
        }

        public IEnumerable<School> GetAllSchools()
        {
            return _schools;
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            return _teachers;
        }

        public School GetSchoolById(int id)
        {
            var found = _schools.FirstOrDefault(x => x.SchoolId == id);
            if (found != null)
            {
                return found;
            }
            throw new ArgumentException("School not found"); //check this--
        }

        public Teacher GetTeacherById(int id)
        {
            var found = _teachers.FirstOrDefault(x => x.TeacherId == id);
            if (found != null)
            {
                return found; 
            }
            throw new ArgumentException("Teacher not found");
        }

        public void UpdateSchool(School school)
        {
            var found = _schools.FirstOrDefault(x => x.SchoolId == school.SchoolId);
            if(found!=null)
            {
                found.SchoolId = school.SchoolId;
                found.SchoolName = school.SchoolName;
                found.SchoolPhone = school.SchoolPhone;
                found.SchoolAddress=school.SchoolAddress;
                found.SchoolEircode = school.SchoolEircode;
            }
        }

        public void UpdateTeacher(Teacher teacher)
        {
            var found = _teachers.FirstOrDefault(x => x.TeacherId == teacher.TeacherId);
            if (found != null)
            {
                found.TeacherId = teacher.TeacherId;
                found.FName = teacher.FName;
                found.SName = teacher.SName;
                found.TeacherPhone = teacher.TeacherPhone;
                found.IsMainRep = teacher.IsMainRep;
            }
            
        }
    }
}
