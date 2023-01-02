using AutoMapper;
using college.APIWEB.Token;
using college.BL.Contract;
using college.DTO;
using college.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;


namespace college.APIWEB.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ApiController
    {
        private readonly IUserBL _userRepository;
        private readonly IMapper _mapper;
        private readonly ITokenApp _tokenApp;
       

        public UserController(IUserBL userRepository, IMapper mapper, ITokenApp tokenApp)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenApp = tokenApp;
        }


        [HttpPost]
        [Route("api/User/register")]
        [ActionName("register")]
        [Authorize]
        public async Task<IHttpActionResult> register(UserRegisterDto userRegister)
        {
            if (ModelState.IsValid)
            {
                if (await _userRepository.CheckExit(x=> x.UserName == userRegister.Username))
                {
                    return BadRequest("user name already exists");
                }               
                var user = _mapper.Map<User>(userRegister);
                return Ok(await _userRepository.Register(user, userRegister.Password));
            }

            return BadRequest(ModelState.ToString());
        }


        [HttpPost]
        [Route("api/User/login")]
        [ActionName("login")]
        public async Task<IHttpActionResult> login(LoginRequestDto login )
        {
            if (!await _userRepository.UserExist(login.Username))
            {
                return BadRequest("no user name with this name" + login.Username);
            }

            var loginResponse = new LoginResponseDto { };
            LoginRequestDto loginrequest = new LoginRequestDto { };
            loginrequest.Username = login.Username.ToLower();
            loginrequest.Password = login.Password;
            IHttpActionResult response;
            var login_Data = await _userRepository.Login(login.Username, login.Password);           
            // if credentials are valid
            if (login_Data!=null)
            {
                string token =  _tokenApp.createToken(loginrequest.Username);
                //return the token
                return Ok<string>(token);
            }
            else
            {
                // if credentials are not valid send unauthorized status code in response
                loginResponse.responseMsg.StatusCode = HttpStatusCode.Unauthorized;
                response = ResponseMessage(loginResponse.responseMsg);
                return response;
            }
        }
    }
}
    

