﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
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
                _context.SaveChanges(); //--Works!!!!
                
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
                _context.SaveChanges();
            }
        }

        public void AddTeam(Team team)
        {
            //var mentor = _context.Teacher.FirstOrDefault(m => m.TeacherId == teacher.TeacherId);
            var newTeam = new Team { Gender = team.Gender, TeamGame = team.TeamGame, Mentor = team.Mentor };
            _context.Team.Add(newTeam);
            _context.SaveChanges();
         }
//        var author = new Author { FirstName = "William", LastName = "Shakespeare" };
//        var book = new Book { Title = "Adventures of Huckleberry Finn" };
//        context.AddRange(author, book);
//context.SaveChanges();

        public IEnumerable<Team> GetAllTeams()
        {
            return _context.Team.ToList();
        }
        public Team GetTeamById(int id)
        {
            var found = _context.Team.Find(id);
            if(found!=null)
            {
                return found;
            }
            throw new Exception("Team not found"); 
        }
        public void UpdateTeam(Team team)
        {
            //find a mentor to add from your school
            //need to assign a mentor to a team
            var found = _context.Team.Find(team.TeamId);
            if(found!=null)
            {
                found.TeamGame = team.TeamGame;
                found.Gender = team.Gender;
                found.Mentor = team.Mentor;

                _context.Team.Update(found); //check this.
                _context.SaveChanges();
            }
        }
        

    }
}


//find teacher/school/team by string var user = _context.Users.Find("johndoe1987");

