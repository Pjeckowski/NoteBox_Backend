using Microsoft.AspNetCore.Mvc;

namespace NoteBoxService.ActionResultProviders
{
    public class NotFoundResultProvider : IActionResultProvider
    {
        public IActionResult GetActionResult<T>(T actionObject)
        {
            return new NotFoundObjectResult(actionObject);
        }
    }
}
