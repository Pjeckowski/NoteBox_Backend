using Notebox.Data.Contract.MajorData;
using Notebox.Data.Contract.UserData;

namespace Notebox.Data
{
    public class ContextFactory: IUserDataContextFactory, IMajorDataContextFactory
    {
        public IUserDataContext GetUserDataContext()
        {
            return new NoteboxDataContext();
        }

        public IMajorDataContext GetMajorDataContext()
        {
            return new NoteboxDataContext();
        }
    }
}
