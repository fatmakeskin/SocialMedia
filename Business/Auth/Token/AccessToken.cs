using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Auth.Token
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
