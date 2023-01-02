using college.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.DTO
{
    public class TeacherDto : BaseDTO
    {
        public string TeacherName { get; set; }       
        public DateTime TeacherBirthDate { get; set; }        
        public double TeacherSalary { get; set; }
    }
}
