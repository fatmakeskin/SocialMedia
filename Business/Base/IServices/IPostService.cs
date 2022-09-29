using SocailMedia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Base.IServices
{
    public interface IPostService
    {
        List<Post> Get();
        Post Get(int id);
        void Update(Post model);
        void Add(Post model);
        void Delete(int id);
    }
}
