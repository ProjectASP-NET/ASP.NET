using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Control.Domain;

namespace Control.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
                private static List<User> users = new List<User>();

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(users);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            user.Id = users.Count + 1;
            users.Add(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }
    }
}
