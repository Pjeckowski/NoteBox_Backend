using Notebox.Data.Contract;

namespace Notebox.Data
{
    public class ContextFactory: IUserDataContextFactory
    {
        public IUserDataContext GetUserDataContext()
        {
            return new NoteboxDataContext();
        }
    }
}
