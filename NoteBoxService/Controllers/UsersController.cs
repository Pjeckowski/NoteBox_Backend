using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteBox.Application.Contract;
using NoteBox.Domain.UserDtos;
using NoteBoxService.ActionResultProviders;

namespace NoteBoxService.Controllers
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
            
        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name="count"), ] int? count, [FromQuery(Name = "start")] int? start)
        {
            var actionResultWrapper = await HandleException(async () => await _userApplication.GetUsersAsync());
            return actionResultWrapper.ActionResultProvider.GetActionResult(actionResultWrapper.ResultObject);
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id)
        {
            var actionResultWrapper = await HandleException(async () => await _userApplication.GetUserByIdAsync(id));
            return actionResultWrapper.IsFaulted ?  actionResultWrapper.ActionResultProvider.GetActionResult(actionResultWrapper.FaultMessage) : actionResultWrapper.ActionResultProvider.GetActionResult(actionResultWrapper.ResultObject);
        }
        
        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UserWithPasswordDto userWithPasswordDto)
        {
            var actionResultWrapper = await HandleException(async () => await _userApplication.AddUserAsync(userWithPasswordDto));
            return actionResultWrapper.ActionResultProvider.GetActionResult(actionResultWrapper.ResultObject);
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
        #endregion

        [HttpGet("{userId}")]
        [Route("{userId}/majors")]
        public async Task<IActionResult> GetUserMajors(int userId)
        {
            var actionResultWrapper = await HandleException(async () => await _majorApplication.GetUserMajors(userId));
            return actionResultWrapper.IsFaulted? actionResultWrapper.ActionResultProvider.GetActionResult(actionResultWrapper.FaultMessage):
                actionResultWrapper.ActionResultProvider.GetActionResult(actionResultWrapper.ResultObject);
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
