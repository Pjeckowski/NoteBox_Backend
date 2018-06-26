using System;
using System.Collections.Generic;
using System.Linq;
using NoteBoxDomain.UserDataModel;

namespace NoteBoxPersistance.UserRepository
{
    public class UserRepository: IUserRepository
    {
        private static List<IUserDataModel> _users;

        public UserRepository()
        {
            _users = new List<IUserDataModel>()
            {
                new UserDataModel()
                {
                    ID = 1,
                    Nick = "RandomNick",
                    Email = "RandomEmail@o2.pl",
                    Password = "RandomPassword"
                }
            };
        }

        public IUserDataModel CreateUser(IUserDataModel user)
        {
            var usersList = _users.ToList();
            usersList.Add(user);
            _users = usersList;
            user.ID = (uint) _users.Count() - 1;
            return user;
        }

        public IUserDataModel UpdateUser(IUserDataModel user)
        {
            _users[(int)user.ID] = user;
            return user;
        }

        public void DeleteUser(uint id)
        {
            _users.Remove(_users[(int)id]);
        }

        public IUserDataModel ReadUser(uint id)
        {
            return _users.SingleOrDefault(x => x.ID.Equals(id));
        }
    }
}
