using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteBox.Application.Contract;
using NoteBox.Domain.UserDtos;
using NoteBox.Service.ActionResultProviders;

namespace NoteBox.Service.Controllers
{
    [Produces("application/json")]
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly IUserAplicatinService _userApplication;
        private readonly IUserMapper _userMapper;
        private readonly IMajorApplicationService _majorApplication;

        public UsersController(IUserAplicatinService userApplicationService, IMajorApplicationService majorApplicationService)
        {
            _userApplication = userApplicationService;
            _userMapper = new UserMapper();
            _majorApplication = majorApplicationService;
        }

        #region usersActions
            
        // GET: Users
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name="count"), ] int? count, [FromQuery(Name = "start")] int? start)
        {
            var actionResultWrapper = await HandleException(async () => await _userApplication.GetUsersAsync());
            return actionResultWrapper.GetActionResult();
        }

        // GET: Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var actionResultWrapper = await HandleException(async () => await _userApplication.GetUserByIdAsync(id));
            return actionResultWrapper.GetActionResult();
        }
        
        // POST: Users
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserWithPasswordDto userWithPasswordDto)
        {
            var actionResultWrapper = await HandleException(async () => await _userApplication.AddUserAsync(userWithPasswordDto));
            return actionResultWrapper.GetActionResult();
        }
        
        
        // PUT: Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Ok();
        }
        
        // DELETE: ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
        #endregion

        [HttpGet("{userId}")]
        [Route("{userId}/majors")]
        public async Task<IActionResult> GetUserMajors(int userId)
        {
            var actionResultWrapper = await HandleException(async () => await _majorApplication.GetUserMajors(userId));
            return actionResultWrapper.GetActionResult();
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
