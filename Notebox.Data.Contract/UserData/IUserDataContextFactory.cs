namespace Notebox.Data.Contract.UserData
{
    public interface IUserDataContextFactory
    {
        IUserDataContext GetUserDataContext();
    }
}
