using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginRegister.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        IUserSevices userService ;

        public userController(IUserSevices userService)
        {
            this.userService = userService;
        }
        //[HttpGet]
        //public async Task<ActionResult> GetuserById([FromRoute] int id)
        //{
        //    User user = await userService.GetUserById(id);
        //    if (user == null)
        //        return BadRequest();
        //    return Ok(user);
        //}

        // GET: api/<loginController>
        [HttpGet]
        public  async Task<ActionResult> Get([FromQuery] string userName, [FromQuery]  string password)
        {
            User user =  await userService.GetUserByUserNameAndPassword(userName, password);
            if (user == null)
                return BadRequest();
            return Ok(user);
        }
        // POST api/<loginController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            User newUser =  await userService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("checkPassword")]
        public ActionResult CheckPassword([FromBody] string pwd)
        {
            return Ok(userService.checkpassword(pwd));
        }

        // PUT api/<loginController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userToUpdate)
        {
           
            if ( await userService.UpdateUserAsync(id, userToUpdate))
                return Ok();
            return BadRequest();
        }


    }
}
