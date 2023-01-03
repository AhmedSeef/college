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
    public class SubjectController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SubjectController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Subject
        public async Task<IHttpActionResult> Get()
        {

            List<SubjectDto> Subjects = _mapper.Map<List<SubjectDto>>(await _unitOfWork.SubjectRepository.GetAll());
            return Ok(Subjects);
        }

        // GET: api/Subject/5
        public async Task<IHttpActionResult> Get(int id)
        {
            SubjectDto Subject = _mapper.Map<SubjectDto>(await _unitOfWork.SubjectRepository.GetById(id));
            return Ok(Subject);
        }
        // POST: api/Subject
        public async Task<IHttpActionResult> Post(SubjectDto SubjectDto)
        {
            if (ModelState.IsValid)
            {
                if (await _unitOfWork.SubjectRepository.CheckExit(x => x.Name == SubjectDto.SubjectName))
                {
                    return BadRequest("Subject already exists");
                }
                var Subject = _mapper.Map<Subject>(SubjectDto);
                _unitOfWork.SubjectRepository.Insert(Subject);
                return Ok(await _unitOfWork.complete());
            }

            return BadRequest(ModelState.ToString());
        }

        // PUT: api/Subject/5
        public async Task<IHttpActionResult> Put(SubjectDto SubjectDto)
        {
            if (ModelState.IsValid)
            {
                if (!await _unitOfWork.SubjectRepository.CheckExit(x => x.Name == SubjectDto.SubjectName))
                {
                    return BadRequest("Subject already not exists");
                }
                var Subject = _mapper.Map<Subject>(SubjectDto);
                _unitOfWork.SubjectRepository.Update(Subject);
                return Ok(await _unitOfWork.complete());
            }

            return BadRequest(ModelState.ToString());
        }

        // DELETE: api/Subject/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var Subject = await _unitOfWork.SubjectRepository.GetById(id);
                if (Subject == null)
                {
                    return BadRequest("Subject already not exists");
                }
                _unitOfWork.SubjectRepository.Delete(Subject);
                return Ok(await _unitOfWork.complete());
            }
            return BadRequest(ModelState.ToString());
        }
    }
}
