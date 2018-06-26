using Microsoft.AspNetCore.Mvc;
using NoteBoxApplication;

namespace NoteBoxService.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IGetUserHandler _getUserHandler;

        public UserController(IGetUserHandler getUserHandler)
        {
            _getUserHandler = getUserHandler;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { val1 = "value1", val2 = "value2" });
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_getUserHandler.Handle(id));
        }
        
        // POST: api/User
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
