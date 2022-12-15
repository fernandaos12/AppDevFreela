using DevFreelaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreelaApp.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsersModel createusermodel)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createusermodel);
        }

        //api/users/1/login
        [HttpPut("{id}")]
        public IActionResult Login(int id, [FromBody] UsersLoginModel login)
        {
            return NoContent();
        }
    }
}
