using Business.Base.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocailMedia.Data.DTO;

namespace SocialMedia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }
        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            try
            {
                var data=userService.GetAll();
                return Ok(data);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpGet(nameof(Get))]
        public IActionResult Get(int id)
        {
            try
            {
                var data = userService.Get(id);
                return Ok(data);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpPost]
        public IActionResult Add(UserDTO user)
        {
            try
            {
                if (user == null)
                    return BadRequest();
                userService.Add(user);
                return Ok();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        [HttpPut]
        public IActionResult Update(UserDTO user)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
