using AutoMapper;
using college.BL.Contract;
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
    public class CourseController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
       


        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;           
        }
        // GET: api/Course
        public async Task<IHttpActionResult> Get()
        {

            List<CourseDto> courses = _mapper.Map<List<CourseDto>>(await _unitOfWork.CourseRepository.GetAll());
             return Ok(courses);
        }

        // GET: api/Course/5
        public async Task<IHttpActionResult> Get(int id)
        {           
            CourseDto course = _mapper.Map<CourseDto>(await _unitOfWork.CourseRepository.GetById(id));
            return Ok(course);
        }

        // POST: api/Course
        public async Task<IHttpActionResult> Post(CourseDto courseDto)
        {
            if (ModelState.IsValid)
            {
                if (await _unitOfWork.CourseRepository.CheckExit(x => x.Name == courseDto.CourseName))
                {
                    return BadRequest("course already exists");
                }
                var course = _mapper.Map<Course>(courseDto);
                _unitOfWork.CourseRepository.Insert(course);
                return Ok(await _unitOfWork.complete());
            }

            return BadRequest(ModelState.ToString());
        }

        // PUT: api/Course/5
        public async Task<IHttpActionResult> Put(CourseDto courseDto)
        {
            if (ModelState.IsValid)
            {
                if (!await _unitOfWork.CourseRepository.CheckExit(x => x.Id == courseDto.Id))
                {
                    return BadRequest("course already not exists");
                }
                var course = _mapper.Map<Course>(courseDto);
                _unitOfWork.CourseRepository.Update(course);
                return Ok(await _unitOfWork.complete());
            }

            return BadRequest(ModelState.ToString());
        }

        // DELETE: api/Course/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var course = await _unitOfWork.CourseRepository.GetById(id);
                if (course == null)
                {
                    return BadRequest("course already not exists");
                }  
                _unitOfWork.CourseRepository.Delete(course);
                return Ok(await _unitOfWork.complete());
            }
            return BadRequest(ModelState.ToString());
        }
    }
}
