using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class School
    {
        [Required]
        [Key]
        public int SchoolId { get; set; }
        [Required]
        public string SchoolName { get; set; } = "";
        [Required]
        public string SchoolPhone { get; set; } = "";
        [Required]
        public string SchoolAddress { get; set; } = "";
        [Required]
        public string SchoolEircode { get; set; } = "";

        //list of teachers for a school
        
        public virtual ICollection<Teacher>? Teachers { get; set; }
        //list of teams for a school
        //public virtual ICollection<Team>? Teams { get; set; } 

    }
}
