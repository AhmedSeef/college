using college.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.DTO
{
    public class SubjectDto : BaseDTO
    {
        public string SubjectName { get; set; }
        public int CourseId { get; set; }
        public int? TeacherId { get; set; }
    }
}
