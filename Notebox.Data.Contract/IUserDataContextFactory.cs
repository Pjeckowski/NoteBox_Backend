namespace Notebox.Data.Contract
{
    public interface IUserDataContextFactory
    {
        IUserDataContext GetUserDataContext();
    }
}
