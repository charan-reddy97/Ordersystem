using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ROS._Core.Repository;

namespace UserMenu.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMenuController : ControllerBase
    {
        IMenuRepository menuRepository;
        public UserMenuController(
           IMenuRepository menuRepository)
        {
            this.menuRepository = menuRepository;
        }
        [HttpGet("byid/{menuid}")]
        public IActionResult Get(int menuid)
        {
            if (menuid > 0)
            {
                var menu = menuRepository.FindById(menuid);

                if (menu != null)
                    return Ok(menu);
                else
                    return NotFound($"Menu with the id:{menuid} cannot be found");
            }
            else
                return BadRequest($"InvalidMenu  Id");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var menu = menuRepository.GetMenus();
            return Ok(menu);
        }
    }
}


