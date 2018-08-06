using System.Collections.Generic;
using System.Linq;
using Notebox.Data.Contract;
using Notebox.UserDBModel.UserDataModel;

namespace Notebox.Data
{
    public class MockUserRepository: IUserRepository
    {
        private readonly IUserDataContextFactory _userDataContextFactory;
        private List<UserDbModel> _users;
        private int _id;
        public MockUserRepository(IUserDataContextFactory userDataContextFactory)
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

        public UserDbModel CreateUser(UserDbModel user)
        {
            user.Id = _id++;
            _users.Add(user);
            return user;
        }

        public void UpdateUser(UserDbModel user)
        {
            var userDb = _users.SingleOrDefault(x => x.Id.Equals(user.Id));
            userDb.Email = user.Email;
            userDb.Nick = user.Nick;
            userDb.Password = user.Password;
        }

        public void DeleteUser(int id)
        {
            var userDb = _users.SingleOrDefault(x => x.Id.Equals(id));
            _users.Remove(userDb);
        }

        public List<UserDbModel> ReadUsers()
        {
            return _users;
        }

        public UserDbModel ReadUser(int id)
        {
            return _users.SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
