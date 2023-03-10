using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace college.DTO
{
    public class LoginResponseDto
    {
        public LoginResponseDto()
        {
            this.Token = "";
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        public string Token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }
    }
}
