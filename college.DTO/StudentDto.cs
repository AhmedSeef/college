using college.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.DTO
{
    public class StudentDto : BaseDTO
    {
        public string StudentName { get; set; }
        public DateTime StudentDateOBirth { get; set; }
        public string StudentRegisterNumber { get; set; }
    }
}
