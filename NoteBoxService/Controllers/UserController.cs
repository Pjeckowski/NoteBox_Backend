using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteBoxApplication;
using NoteBoxDomain.UserDto;

namespace NoteBoxService.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserAplicatinService _userApplication;

        public UserController(IUserAplicatinService userApplicationService)
        {
            _userApplication = userApplicationService;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(); //HandleException(() => _userApplication.GetUsers());
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(); //HandleException(() => _userApplication.GetUserById(id));
        }
        
        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserWithPasswordDto userWithPasswordDto)
        {
            return await HandleException(() => _userApplication.AddUser(userWithPasswordDto));
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

        private async Task<IActionResult> HandleException<T>( Func<Task<T>> actionFunc)
        {
            T result;
            try
            {
                result =  await actionFunc();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

            return Ok(result);
        }
    }
}
