using NoteBox.Service.ActionResultProviders;

namespace NoteBox.Service
{
    public class ActionResultWrapper<T>
    {
        public IActionResultProvider ActionResultProvider { get; set; }
        public T ResultObject { get; set; }
        public bool IsFaulted { get; set; }
        public string FaultMessage { get; set; }
    }
}
