using AutoMapper;
using college.BL.Contract;
using college.DTO;
using college.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace college.APIWEB.Controllers
{
  
    public class UserController : ApiController
    {
        private readonly IUserBL _userRepository;
        private readonly IMapper _mapper;
        public UserController(IUserBL userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        
        public async Task<IHttpActionResult> Post(UserRegisterDto userRegister)
        {
            if (ModelState.IsValid)
            {
                if (await _userRepository.UserExist(userRegister.Username))
                {
                    return BadRequest("user name already exists");
                }               
                var user = _mapper.Map<User>(userRegister);
                return Ok(await _userRepository.Register(user, userRegister.Password));
            }

            return BadRequest(ModelState.ToString());
        }
    }
}
