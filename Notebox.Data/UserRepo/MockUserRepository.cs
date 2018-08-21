using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notebox.Data.Contract;
using Notebox.Data.Contract.UserData;
using Notebox.DBModels.UserDataModel;

namespace NoteBox.Data.UserRepo
{
    public class MockUserRepository: IUserRepository
    {
        private List<UserDbModel> _users;
        private int _id;
        public MockUserRepository()
        {
            _users = new List<UserDbModel>();
            for (int i = 1; i < 21; i++)
            {
                _users.Add(new UserDbModel()
                {
                    Id = i,
                    Nick = $"RandomNick{i}",
                    Email = $"RandomEmail{i}@o2.pl",
                    Password = $"ranodmPassword{i}"
                });
            }
            _id = 21;
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
            return _users.Skip(5).Take(5).ToList();
        }

        public async Task<UserDbModel> ReadUserAsync(int id)
        {
            return _users.SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
