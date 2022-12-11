using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository
    {
        //schools
        public IEnumerable<School> GetAllSchools();
        
        public School GetSchoolById(int id);
        //public School GetSchoolByName(string name); possible
        public void AddSchool(School school);
        public void UpdateSchool(School school);//possibly add an id here
        public void DeleteSchool(int id);

        //teachers
        public IEnumerable<Teacher> GetAllTeachers();
        public Teacher GetTeacherById(int id);
        //public Teacher GetTeacherByName(string name); //possible
        public void AddTeacher(Teacher teacher);
        public void UpdateTeacher(Teacher teacher); //possibly add id here as well
        public void DeleteTeacher(int id);
        public void AddTeam(Team team);
        public IEnumerable<Team> GetAllTeams();
        public Team GetTeamById(int id);
        public void UpdateTeam(Team team);


    }
}


