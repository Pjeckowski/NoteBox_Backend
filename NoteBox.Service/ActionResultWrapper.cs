using Microsoft.AspNetCore.Mvc;
using NoteBox.Service.ActionResultProviders;

namespace NoteBox.Service
{
    public class ActionResultWrapper<T>
    {
        public IActionResultProvider ActionResultProvider { get; set; }
        public T ResultObject { get; set; }
        public bool IsFaulted { get; set; }
        public string FaultMessage { get; set; }

        public IActionResult GetActionResult()
        {
            return IsFaulted ? ActionResultProvider.GetActionResult(FaultMessage) : ActionResultProvider.GetActionResult(ResultObject);
        }
    }
}
