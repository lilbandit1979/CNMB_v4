using CNMB_v4.Controllers;
using Models;
using Repository;

namespace CNMB_Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void CreateCheck()
        {
            IRepository repo = new MockDB();
            SchoolsController sc = new SchoolsController(repo);

            School newSchool = new School()
            {
                SchoolId = 1,
                SchoolName = "St. Conleth",
                SchoolPhone = "045431179",
                SchoolAddress = "Kildare",
                SchoolEircode = "w12f320"
            };

            repo.AddSchool(newSchool);
            var exists = repo.GetSchoolById(1);

            Assert.IsNotNull(exists);

        }


        [TestMethod]
        public void CheckThat_Editing_Isworking() 
        {
            IRepository repo = new MockDB();
            //SchoolsController sc = new SchoolsController(repo);

            School schoolToEdit = new School()
            {
                SchoolId = 1,
                SchoolName = "St. Conleth and Marys",
                SchoolPhone = "045431179",
                SchoolAddress = "Kildare",
                SchoolEircode = "w12f320"
            };

            repo.UpdateSchool(schoolToEdit);
           
            var changed = repo.GetSchoolById(1);

            Assert.AreEqual(changed.SchoolName, "St.Conleth and Marys");
            Assert.AreEqual(changed.SchoolEircode, "w12f320");

        }
    }
}
    




//using StudentInfoAPI_V2.Controllers;
//using StudentInfoAPI_V2.Models;
//using StudentInfoAPI_V2.Repository;
//using System.Diagnostics;
//using System.Reflection;
//using System.Xml.Linq;

//namespace StudentInfoAPI_V2
//{
//    [TestClass]
//    public class Tests
//    {
//        [TestMethod]
//        public void CheckThat_Editing_Isworking()
//        {
//            IRepository repo = new MockDB();
//            StudentMockDBController smc = new StudentMockDBController(repo);

//            StudentExam studentToEdit = new StudentExam
//            {
//                StudentID = 1,
//                Name = "Steve",
//                Module = "EAD",
//                Grade = 50,
//                MatureStudent = true
//            };

//            smc.PutStudentExam(studentToEdit, 1);

//            var changed = smc.GetStudentExam(1);


//            Assert.AreEqual(changed.Value.Name, "Steve");
//            Assert.AreEqual(changed.Value.Module, "EAD");
//            Assert.AreEqual(changed.Value.Grade, 50);
//        }
//       
//    }
//}