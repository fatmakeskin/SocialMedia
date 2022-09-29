using Business.Base.IServices;
using DataAccess.Repositories;
using SocailMedia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base.Services
{
    public class PostService : IPostService
    {

        public void Add(Post model)
        {
            using (var data=new MongoRepository<Post>())
            {
                data.Add(model);
            }
        }

        public void Delete(int id)
        {
            using (var data=new MongoRepository<Post>())
            {
                data.Delete(x=>x.PostId.Equals(id));
            }
        }

        public List<Post> Get()
        {
            using (var data=new MongoRepository<Post>())
            {
               var result= data.GetAll().ToList();
               return result;
            }
        }

        public Post Get(int id)
        {
            using(var data=new MongoRepository<Post>())
            {
                var response=data.Get(x => x.PostId.Equals(id));
                return response;
            }
        }

        public void Update(Post model)
        {
            using (var data=new MongoRepository<Post>())
            {
                data.Update(model);
            }
        }
    }
}
