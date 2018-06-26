using NoteBoxDomain.UserDataModel;

namespace NoteBoxPersistance.UserRepository
{
    public interface IUserRepository
    {
        IUserDataModel CreateUser(IUserDataModel user);

        IUserDataModel UpdateUser(IUserDataModel user);

        void DeleteUser(uint id);

        IUserDataModel ReadUser(uint id);
    }
}
