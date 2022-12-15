using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class Teacher
    {
        [Required]
        [Key]
        public int TeacherId { get; set; }
        [Required]
        public string FName { get; set; } = "";
        [Required]
        public string SName { get; set; } = "";
        [Required]
        public string TeacherPhone { get; set; } = "";
        [Required]
        public bool IsMainRep { get; set; }= false;

        //foreign key back to School
        public int SchoolId { get; set; } 

        
        

    }
}
