using college.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.Models
{
    [Table("Course")]
    public class Course : BaseModel, INameBase
    {
        public Course()
        {
            subjects = new List<Subject>();
        }
        public string Name { get ; set ; }
        public List<Subject> subjects { get;set; }
    }
}
