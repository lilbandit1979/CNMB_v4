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
        //StudentContext ct;
        //public RealSql()
        //{
        //    ct = new StudentContext();
        //}
        //~RealSql()
        //{
        //    if (ct != null) ct.Dispose();
        //}


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
            _db.Add(school);
            _db.SaveChanges();

        }

        public void AddTeacher(Teacher teacher)
        {
            _db.Add(teacher);
            _db.SaveChanges();
        }

        public void DeleteSchool(int id)
        {
            var found = _db.School.Find(id);
            if (found != null)
            {
                _db.Remove(found);
                _db.SaveChanges();
            }
        }

        public void DeleteTeacher(int id)
        {
            _db.DeleteTeacher(id);
        }

        public IEnumerable<School> GetAllSchools()
        {
            return _db.GetAllSchools();
        }

        public IEnumerable<Teacher> GetAllTeachers()
        {
           return _db.GetAllTeachers();
        }

        public School GetSchoolById(int id)
        {
            var found = _db.W
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


//find teacher/school/team by string var user = context.Users.Find("johndoe1987");

//namespace Repository.Repo
//{
//    public class RealSql : IRepository
//    {
//        StudentContext ct;
//        public RealSql()
//        {
//            ct = new StudentContext();
//        }
//        ~RealSql()
//        {
//            if (ct != null) ct.Dispose();
//        }

//        public void AddStudent(Student s)
//        {
//            ct.Students.Add(s);

//            ct.SaveChanges();
//        }
//        public List<Module> GetModules()
//        {
//            return ct.Modules.ToList();
//        }
//        public List<Student> GetStudents()
//        {
//            return ct.Students.ToList();
//        }
//        public void AddModule(Module module)
//        {
//            ct.Modules.Add(module);
//        }


//    }
//}
