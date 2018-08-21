using Microsoft.AspNetCore.Mvc;

namespace NoteBox.Service.ActionResultProviders
{
    public class NotFoundResultProvider : IActionResultProvider
    {
        public IActionResult GetActionResult<T>(T actionObject)
        {
            return new NotFoundObjectResult(actionObject);
        }
    }
}
