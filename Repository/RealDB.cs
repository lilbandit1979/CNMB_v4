using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RealDB : IRepository
    {
        CNMBContext _db;
        public RealDB (CNMBContext db) //constructor
        {
            _db = db;
        }

        public void AddSchool(School school)
        {
            throw new NotImplementedException();
        }

        public void AddTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public void DeleteSchool(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteTeacher(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<School> GetAllSchools()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
            throw new NotImplementedException();
        }

        public School GetSchoolById(int id)
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacherById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSchool(School school)
        {
            throw new NotImplementedException();
        }

        public void UpdateTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
