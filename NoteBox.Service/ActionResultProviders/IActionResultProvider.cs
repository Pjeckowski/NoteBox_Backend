using Microsoft.AspNetCore.Mvc;

namespace NoteBox.Service.ActionResultProviders
{
    public interface IActionResultProvider
    {
        IActionResult GetActionResult<T>(T actionObject);
    }
}
