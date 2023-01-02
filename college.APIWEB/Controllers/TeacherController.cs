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
    public class TeacherController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TeacherController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Teacher
        public async Task<IHttpActionResult> Get()
        {

            List<TeacherDto> Teachers = _mapper.Map<List<TeacherDto>>(await _unitOfWork.TeacherRepository.GetAll());
            return Ok(Teachers);
        }

        // GET: api/Teacher/5
        public async Task<IHttpActionResult> Get(int id)
        {
            TeacherDto Teacher = _mapper.Map<TeacherDto>(await _unitOfWork.TeacherRepository.GetById(id));
            return Ok(Teacher);
        }
        // POST: api/Teacher
        public async Task<IHttpActionResult> Post(TeacherDto TeacherDto)
        {
            if (ModelState.IsValid)
            {
                if (await _unitOfWork.TeacherRepository.CheckExit(x => x.Name == TeacherDto.TeacherName))
                {
                    return BadRequest("Teacher already exists");
                }
                var Teacher = _mapper.Map<Teacher>(TeacherDto);
                _unitOfWork.TeacherRepository.Insert(Teacher);
                return Ok(await _unitOfWork.complete());
            }

            return BadRequest(ModelState.ToString());
        }

        // PUT: api/Teacher/5
        public async Task<IHttpActionResult> Put(TeacherDto TeacherDto)
        {
            if (ModelState.IsValid)
            {
                if (!await _unitOfWork.TeacherRepository.CheckExit(x => x.Name == TeacherDto.TeacherName))
                {
                    return BadRequest("Teacher already not exists");
                }
                var Teacher = _mapper.Map<Teacher>(TeacherDto);
                _unitOfWork.TeacherRepository.Update(Teacher);
                return Ok(await _unitOfWork.complete());
            }

            return BadRequest(ModelState.ToString());
        }

        // DELETE: api/Teacher/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var Teacher = await _unitOfWork.TeacherRepository.GetById(id);
                if (Teacher == null)
                {
                    return BadRequest("Teacher already not exists");
                }
                _unitOfWork.TeacherRepository.Delete(Teacher);
                return Ok(await _unitOfWork.complete());
            }
            return BadRequest(ModelState.ToString());
        }
    }
}

