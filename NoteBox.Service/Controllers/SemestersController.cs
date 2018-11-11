using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteBox.Service.ActionResultProviders;

namespace NoteBox.Service.Controllers
{
    [Produces("application/json")]
    [Route("semesters")]
    public class SemestersController : Controller
    {
        // GET: api/Semesters
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET: api/Semesters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }
        
        // POST: api/Semesters
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Semesters/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
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
