using Business.Auth.Token;
using Business.Configuration.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base.IServices
{
    public interface IAuthService
    {
        CommandResponse VerifyPassword(string email, string password);
        AccessToken Login(string email, string password);
    }
}
