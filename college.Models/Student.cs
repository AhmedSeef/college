using college.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.Models
{
    [Table("Student")]
    public class Student : BaseModel, INameBase, IBirthDateBase
    {
        public Student()
        {
            Subjects = new List<Subject>();
        }
        [Required]
        public string Name { get ; set ; }
        [Required]
        public DateTime BirthDate { get ; set ; }
        public List<Subject> Subjects { get; set ; }
    }
}
