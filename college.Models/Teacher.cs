using college.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace college.Models
{
    [Table("Teacher")]
    public class Teacher : BaseModel, INameBase, IBirthDateBase
    {
        [Required]
        public string Name { get; set ; }
        [Required]
        public DateTime BirthDate { get ; set ; }
        public Subject Subject { get; set; }
    }
}
