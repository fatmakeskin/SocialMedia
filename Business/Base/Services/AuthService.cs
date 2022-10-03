using Business.Configuration.Response;
using DataAccess.MySqlBase;
using DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SocailMedia.Data.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base.Services
{
    public class AuthService : Attribute
    {
        private readonly IMySqlRepository<User> _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IMySqlRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        public CommandResponse VerifyPassword(string email, string password)
        {

        }
    }
}
