using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notebox.Data.Contract;
using Notebox.Data.Contract.UserData;
using Notebox.DBModels.UserDataModel;

namespace Notebox.Data.UserRepo
{
    public class MockUserRepository: IUserRepository
    {
        private List<UserDbModel> _users;
        private int _id;
        public MockUserRepository()
        {
            _users = new List<UserDbModel>
            {
                new UserDbModel()
                {
                    Id = 1,
                    Email = "kupa@o2.pl",
                    Nick = "kupa",
                    Password = "kupa123"
                },
                new UserDbModel()
                {
                    Id = 2,
                    Email = "siku@o2.pl",
                    Nick = "siku",
                    Password = "siku123"
                },
                new UserDbModel()
                {
                    Id = 3,
                    Email = "rzygi@o2.pl",
                    Nick = "rzygi",
                    Password = "rzygi123"
                }
            };

            _id = 4;
        }

        public async Task<UserDbModel> CreateUserAsync(UserDbModel user)
        {
            user.Id = _id++;
            _users.Add(user);
            return user;
        }

        public async Task UpdateUserAsync(UserDbModel user)
        {
            var userDb = _users.SingleOrDefault(x => x.Id.Equals(user.Id));
            userDb.Email = user.Email;
            userDb.Nick = user.Nick;
            userDb.Password = user.Password;
        }

        public async Task DeleteUserAsync(int id)
        {
            var userDb = _users.SingleOrDefault(x => x.Id.Equals(id));
            _users.Remove(userDb);
        }

        public async Task<List<UserDbModel>> ReadUsersAsync()
        {
            return _users;
        }

        public async Task<UserDbModel> ReadUserAsync(int id)
        {
            return _users.SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
