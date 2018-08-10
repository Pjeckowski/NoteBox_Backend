using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteBoxApplication;
using NoteBoxDomain.UserDto;
using NoteBoxService.ActionResultProviders;

namespace NoteBoxService.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserAplicatinService _userApplication;
        private readonly IUserMapper _userMapper;

        public UserController(IUserAplicatinService userApplicationService)
        {
            _userApplication = userApplicationService;
            _userMapper = new UserMapper();
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await HandleException(async () => await _userApplication.GetUsersAsync());
            return result.ActionResultProvider.GetActionResult(result.ResultObject);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await HandleException(async () => await _userApplication.GetUserByIdAsync(id));
            return result.IsFaulted ?  result.ActionResultProvider.GetActionResult(result.FaultMessage) : result.ActionResultProvider.GetActionResult(result.ResultObject);
        }
        
        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserWithPasswordDto userWithPasswordDto)
        {
            var result = await HandleException(async () => await _userApplication.AddUserAsync(userWithPasswordDto));
            return result.ActionResultProvider.GetActionResult(result.ResultObject);
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

        //why not just returning action result??
        //later if I try to separate application contract from service (that application layer wont return DTO object only some Domain or App object)
        //I won't know which adapter to use in Exception handler for example is it UserWithPasswordAdapter or just UserAdapter due to it is generic method
        //could use some adapterBus, but it would force me to create some reflection based structure 
        private static async Task<ActionResultWrapper<T>> HandleException<T>( Func<Task<T>> actionFunc)
        {
            T result;
            try
            {
                result =  await actionFunc();
            }
            catch (Exception e)
            {
                return new ActionResultWrapper<T>
                {
                    ActionResultProvider = new NotFoundResultProvider(),
                    IsFaulted = true,
                    FaultMessage = e.Message
                };
            }

            return new ActionResultWrapper<T>
            {
                ActionResultProvider = new OkResultProvider(),
                ResultObject = result,
                IsFaulted = false
            };
        }
    }
}
