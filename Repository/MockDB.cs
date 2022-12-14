using Microsoft.OpenApi.Validations;
using Models;
using NuGet.DependencyResolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            new School {SchoolId=1,SchoolName="Conleths",SchoolPhone="045431179",SchoolAddress="Newbridge",SchoolEircode="W12F659"},
            new School {SchoolId=2,SchoolName="Patricians",SchoolPhone="045238867",SchoolAddress="Newbridge",SchoolEircode="W12F658"},
            new School {SchoolId=3,SchoolName="Corbans",SchoolPhone="045651175",SchoolAddress="Naas",SchoolEircode="Z14F250"},
            new School {SchoolId=4,SchoolName="Convent",SchoolPhone="045318860",SchoolAddress="Leixlip",SchoolEircode="E56F195"}
        };

        public static List<Team> _teams = new List<Team>()
        {
            new Team { TeamId=0,Gender=Gender.boys,TeamGame=TeamType.SeniorFootball/*Mentor=_teachers.FirstOrDefault(x=>x.TeacherId==1)*/ }, //16th Dec
            new Team { TeamId=1,Gender=Gender.girls,TeamGame=TeamType.U11Camogie,/*Mentor=_teachers.FirstOrDefault(x=>x.TeacherId==2)*/}// 16th Dec
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

        public void UpdateSchool(School school) //check --only takes school. Maybe should take int id as well?
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

        public void AddTeam(Team team)
        {
           _teams.Add(team);
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _teams.ToList();
        }

        public Team GetTeamById(int id)
        {
            var found = _teams.FirstOrDefault(t=>t.TeamId==id);
            if(found!=null)
            {
                return found;
            }
            throw new ArgumentException("Team not found");
        }

        public void UpdateTeam(Team team)
        {
            var found = _teams.FirstOrDefault(t => t.TeamId == team.TeamId);
            if (found != null)
            {
                //found.TeamId = team.TeamId;
                found.TeamGame = team.TeamGame;
                found.Gender = team.Gender;
                //found.Mentor = team.Mentor; --16th Dec
            }
        }
  
    }
}
