using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
        [Required]
        [Key]
        public int TeamId { get; set; }
        [Required]
        public  Gender Gender { get; set; }
        [Required]
        public TeamType TeamGame { get; set; } //football, hurling etc.
        [Required]
        public Teacher? Mentor { get; set; } //can be null
        
        //Both added 11thDec --cant add a mentor to a team
        //list of teachers for a school
        //public virtual ICollection<Teacher>? Teachers { get; set; }
        ////useful to be able to get the school without querying the ID
        //public School? School { get; set; }
    }
}
