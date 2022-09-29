using AutoMapper;
using Business.Base.IServices;
using DataAccess.MySqlBase;
using DataAccess.UoW;
using SocailMedia.Data.DTO;
using SocailMedia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        public UserService(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public void Add(UserDTO model)
        {
            using (var uow = new UnitofWork())
            {
                var data = mapper.Map<User>(model);
                uow.GetMySqlRepository<User>().Add(data);
                uow.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var uow=new UnitofWork())
            {
                var data = uow.GetMySqlRepository<User>().Get(x => x.Id.Equals(id));
                uow.GetMySqlRepository<User>().Delete(data);
                uow.SaveChanges();
            }
        }

        public List<UserDTO> Get()
        {
            using (var uow = new UnitofWork())
            {
                var data = uow.GetMySqlRepository<User>().GetAll().ToList();
                var model=mapper.Map<List<UserDTO>>(data);
                return model;
            }
        }

        public UserDTO Get(int id)
        {
            using (var uow = new UnitofWork())
            {
                var data = uow.GetMySqlRepository<User>().Get(x => x.Id.Equals(id));
                var model=mapper.Map<UserDTO>(data);
                return model;
            }
        }
        public void Update(UserDTO model)
        {
            using (var uow=new UnitofWork())
            {
                var data = mapper.Map<User>(model);
                uow.GetMySqlRepository<User>().Update(data);
                uow.SaveChanges();
            }
        }
    }
}
