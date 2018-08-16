using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NoteBox.Application.Contract;
using NoteBox.Domain.MajorDtos;
using NoteBoxService.ActionResultProviders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NoteBoxService.Controllers
{
    [Route("[controller]")]
    public class MajorsController : Controller
    {
        private readonly IMajorApplicationService _majorApplication;
        private readonly IMajorMapper _majorMapper;

        public MajorsController(IMajorApplicationService majorApplication, IMajorMapper majorMapper)
        {
            _majorApplication = majorApplication;
            _majorMapper = majorMapper;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var actionResultWrapper = await HandleException(async () => await _majorApplication.GetMajorsAsync());
            return actionResultWrapper.ActionResultProvider.GetActionResult(actionResultWrapper.ResultObject);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var actionResultWrapper = await HandleException(async () => await _majorApplication.GetMajorByIdAsync(id));
            return actionResultWrapper.IsFaulted?  actionResultWrapper.ActionResultProvider.GetActionResult(actionResultWrapper.FaultMessage): 
                actionResultWrapper.ActionResultProvider.GetActionResult(actionResultWrapper.ResultObject);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]MajorDto majorDto)
        {
            var actionResultWrapper = await HandleException(async () => await _majorApplication.AddMajorAsync(majorDto));
            return actionResultWrapper.ActionResultProvider.GetActionResult(actionResultWrapper.ResultObject);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]string value)
        {
            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //why not just returning action result??
        //later if I try to separate application contract from service (that application layer wont return DTO object only some Domain or App object)
        //I won't know which adapter to use in Exception handler for example is it UserWithPasswordAdapter or just UserAdapter due to it is generic method
        //could use some adapterBus, but it would force me to create some reflection based structure 
        private static async Task<ActionResultWrapper<T>> HandleException<T>(Func<Task<T>> actionFunc)
        {
            T result;
            try
            {
                result = await actionFunc();
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
