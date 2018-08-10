using Microsoft.AspNetCore.Mvc;

namespace NoteBoxService.ActionResultProviders
{
    public class OkResultProvider : IActionResultProvider
    {
        public IActionResult GetActionResult<T>(T actionObject)
        {
            return new OkObjectResult(actionObject);
        }
    }
}
