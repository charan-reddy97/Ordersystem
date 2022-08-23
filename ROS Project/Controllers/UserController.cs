using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ROS.Core.Entities;
using ROS.Core.Repository;

namespace ROS_Project.Controllers
{
    [Route("api/[controller]")]
   
    [ApiController]
    [Authorize(Roles = "KitchenAdmin")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(
           IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        [HttpGet("byid/{userid}")]
        public IActionResult Get(int userid)
        {
            if (userid > 0)
            {
                var user = userRepository.FindUserById(userid);

                if (User != null)
                    return Ok(User);
                else
                    return NotFound($"User with the id:{userid} cannot be found");
            }
            else
                return BadRequest($"InvalidUser Id");
        }



        [HttpPost]
        public IActionResult Post(User user)
        {
            userRepository.Add(user);
            return Created($"/api/users/{user.Id}", user);
        }

        [HttpPut]
        public IActionResult Put(User user)
        {
            if (user.Id > 0)
            {
                userRepository.Update(user);
                return Ok();
            }
            else
                return BadRequest($"Invalid user Id");
        }
        [HttpGet]
        public IActionResult Get()
        {
            var users = userRepository.GetUser();
            return Ok(users);
        }
    }
       
}