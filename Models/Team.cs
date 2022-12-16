using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public enum Gender
    {
        boys=1,
        girls=2
    }
    public enum TeamType
    {
        U10Football=1,
        U11Football=2,
        SeniorFootball=3,
        U11Camogie=4,
        SeniorCamogie=5,
        U11Hurling=6,
        SeniorHurling=7
    }
    public class Team
    {
        //old
        //[Required]
        //[Key]
        //public int TeamId { get; set; }
        //[Required]
        //public  Gender Gender { get; set; }
        //[Required]
        //public TeamType TeamGame { get; set; } //football, hurling etc.
        //[Required]
        //public Teacher? Mentor { get; set; } //can be null 
        //public int TeacherId { get; set; }
        //public School? School { get; set; } //try nullable 

        //foreign key back to school
        //public int? SchoolID { get; set; }
        //end old
        //new begins
        [Required]
        [Key]
        public int TeamId { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public TeamType TeamGame { get; set; } //football, hurling etc.
        [Required]
        public Teacher? Mentor { get; set; } //can be null 
        public int TeacherId { get; set; }
        public int SchoolId { get; set; }
    }
}
