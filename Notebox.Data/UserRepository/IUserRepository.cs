using System.Collections.Generic;
using Notebox.UserDBModel.UserDataModel;

namespace Notebox.Data.UserRepository
{
    public interface IUserRepository
    {
        UserDbModel CreateUser(UserDbModel user);

        void UpdateUser(UserDbModel user);

        void DeleteUser(int id);

        List<UserDbModel> ReadUsers();

        UserDbModel ReadUser(int id);
    }
}
