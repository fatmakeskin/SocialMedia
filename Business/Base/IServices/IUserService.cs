using SocailMedia.Data.DTO;
using SocailMedia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base.IServices
{
    public interface IUserService
    {
        List<UserDTO> Get();
        UserDTO Get(int id);
        void Update(UserDTO model);
        void Add(UserDTO model);
        void Delete(int id);
    }
}
