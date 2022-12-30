using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace college.APIWEB.Token
{
    public interface ITokenApp
    {
        string createToken(string username);
    }
}
