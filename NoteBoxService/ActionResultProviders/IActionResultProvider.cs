using Microsoft.AspNetCore.Mvc;

namespace NoteBoxService.ActionResultProviders
{
    public interface IActionResultProvider
    {
        IActionResult GetActionResult<T>(T actionObject);
    }
}
