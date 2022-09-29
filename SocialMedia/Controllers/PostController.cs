using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using SocailMedia.Data.DTO;
using SocailMedia.Data.Entities;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            using (var data = new MongoRepository<Post>())
            {
                var model = data.GetAll().ToList();
                return Ok(model);
            }
        }
        [HttpGet(nameof(Get))]
        public IActionResult Get(Post model)
        {
            using (var data=new MongoRepository<Post>())
            {
                var repo = data.Get(x => x.PostId.Equals(model.PostId));
                if (repo == null) return NotFound();
                return Ok(repo);
                
            }
        }

        [HttpPost(nameof(Add))] 
        public IActionResult Add(Post model)
        {
            using (var data=new MongoRepository<Post>())
            {
                try
                {
                    if (model == null)
                        return BadRequest();
                    data.Add(model);
                    return Ok(model);
                    
                }
                catch (Exception)
                {

                    return StatusCode(500);
                }
            }
        }
        [HttpPut(nameof(Update))]
        public IActionResult Update(Post model)
        {
            using (var data = new MongoRepository<Post>())
            {
                try
                {
                    if (model == null)
                        return BadRequest();
                    data.Update(model);
                    return Ok(model);

                }
                catch (Exception)
                {

                    return StatusCode(500);
                }
            }
        }
        [HttpDelete(nameof(Delete))]
        public IActionResult Delete(Post model)
        {
            using (var data=new MongoRepository<Post>())
            {
                try
                {
                    if (model == null)
                        return BadRequest();
                    data.Delete(x=>x.Equals(model.PostId));
                    return Ok(model);
                }
                catch (Exception)
                {

                    return StatusCode(500);
                }
            }
        }

    }
}
