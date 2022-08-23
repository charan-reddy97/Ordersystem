using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ROS._Core.Entities;
using ROS._Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ROS_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class MenuController : ControllerBase
    {
        
        private readonly IMenuRepository menuRepository;
        public MenuController(
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


        //[Authorize(Roles = "KitchenAdmin")]
        [HttpPost]
        public IActionResult Post(Menu menu)
        {
            menuRepository.Add(menu);
            return Ok(menu);
        }
       // [Authorize(Roles = "KitchenAdmin")]
        [HttpPut]
        public IActionResult Put(Menu menu)
        {
            if (menu.Id > 0)
            {
                menuRepository.Update(menu);
                return Ok();
            }
            else
                return BadRequest($"Invalid menu Id");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                menuRepository.Delete(id);
                return Ok();
            }
            else
                return BadRequest($"Invalid Menu Id");
        }




        [HttpGet]
        public IActionResult Get()
        {
            var menu = menuRepository.GetMenus();
            return Ok(menu);
        }

    }

}


