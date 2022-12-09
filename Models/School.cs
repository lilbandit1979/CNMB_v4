using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class School
    {
        [Required]
        [Key]
        public int SchoolID { get; set; }
        [Required]
        public string SchoolName { get; set; } = "";
        [Required]
        public string SchoolPhone { get; set; } = "";
        [Required]
        public string SchoolAddress { get; set; } = "";
        [Required]
        public string SchoolEircode { get; set; } = ""; //maybe call a map API??

        //list of teachers for a school
        public virtual ICollection<Teacher>? Teachers { get; set; }



    }
}
