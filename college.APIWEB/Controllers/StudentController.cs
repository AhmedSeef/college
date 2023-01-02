using AutoMapper;
using college.DTO;
using college.Models;
using college.Repository.Contract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace college.APIWEB.Controllers
{
    public class StudentController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Student
        public async Task<IHttpActionResult> Get()
        {

            List<StudentDto> students = _mapper.Map<List<StudentDto>>(await _unitOfWork.StudentRepository.GetAll());
            return Ok(students);
        }

        // GET: api/Student/5
        public async Task<IHttpActionResult> Get(int id)
        {
            StudentDto student = _mapper.Map<StudentDto>(await _unitOfWork.StudentRepository.GetById(id));
            return Ok(student);
        }
        // POST: api/Student
        public async Task<IHttpActionResult> Post(StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                if (await _unitOfWork.StudentRepository.CheckExit(x => x.RegistrationNumber == studentDto.StudentRegisterNumber))
                {
                    return BadRequest("student already exists");
                }
                var student = _mapper.Map<Student>(studentDto);
                _unitOfWork.StudentRepository.Insert(student);
                return Ok(await _unitOfWork.complete());
            }

            return BadRequest(ModelState.ToString());
        }

        // PUT: api/Student/5
        public async Task<IHttpActionResult> Put(StudentDto studentDto)
        {
            if (ModelState.IsValid)
            {
                if (!await _unitOfWork.StudentRepository.CheckExit(x => x.RegistrationNumber == studentDto.StudentRegisterNumber))
                {
                    return BadRequest("Student already not exists");
                }
                var student = _mapper.Map<Student>(studentDto);
                _unitOfWork.StudentRepository.Update(student);
                return Ok(await _unitOfWork.complete());
            }

            return BadRequest(ModelState.ToString());
        }

        // DELETE: api/Student/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var student = await _unitOfWork.StudentRepository.GetById(id);
                if (student == null)
                {
                    return BadRequest("student already not exists");
                }
                _unitOfWork.StudentRepository.Delete(student);
                return Ok(await _unitOfWork.complete());
            }
            return BadRequest(ModelState.ToString());
        }
    }
}
