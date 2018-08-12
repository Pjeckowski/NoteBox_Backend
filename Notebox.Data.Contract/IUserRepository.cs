using System.Collections.Generic;
using System.Threading.Tasks;
using Notebox.DBModels.UserDataModel;

namespace Notebox.Data.Contract
{
    public interface IUserRepository
    {
        Task<UserDbModel> CreateUserAsync(UserDbModel user);
        Task<List<UserDbModel>> ReadUsersAsync();
        Task<UserDbModel> ReadUserAsync(int id);
        Task UpdateUserAsync(UserDbModel user);
        Task DeleteUserAsync(int id);
    }
}
