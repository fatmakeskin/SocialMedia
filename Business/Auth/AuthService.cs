using DataAccess.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Business.Auth
{
    public class AuthService:Attribute
    {
        public AuthModel Authenticate(string kullaniciAdi, string sifre)
        {
            _appSetting setting= new _appSetting();
            setting.secret = Environment.GetEnvironmentVariable("SecurityKey");
            using (var model= new MongoRepository<AuthModel>())
            {
                var user = model.Get(x => x.KullaniciAdi.Equals(kullaniciAdi) && x.Sifre.Equals(sifre));

                if(user== null)
                    return null;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(setting.secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                // Sifre null olarak gonderilir.
                user.Sifre = null;

                return user;
            }
        }
        
        public class _appSetting
        {
            public string secret { get; set; }
        }
    }
}
