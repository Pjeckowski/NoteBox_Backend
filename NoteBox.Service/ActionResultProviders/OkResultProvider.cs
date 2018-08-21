using Microsoft.AspNetCore.Mvc;

namespace NoteBox.Service.ActionResultProviders
{
    public class OkResultProvider : IActionResultProvider
    {
        public IActionResult GetActionResult<T>(T actionObject)
        {
            return new OkObjectResult(actionObject);
        }
    }
}
