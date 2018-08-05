using System.Collections.Generic;
using System.Linq;
using Notebox.Data.Contract;
using Notebox.UserDBModel.UserDataModel;

namespace Notebox.Data
{
    public class UserRepository: IUserRepository
    {
        private readonly IUserDataContextFactory _userDataContextFactory;

        public UserRepository(IUserDataContextFactory userDataContextFactory)
        {
            _userDataContextFactory = userDataContextFactory;
        }

        public UserDbModel CreateUser(UserDbModel user)
        {
            using (var context = _userDataContextFactory.GetUserDataContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return context.Users.SingleOrDefault(x => x.Nick.Equals(user.Nick));
            }
        }

        public void UpdateUser(UserDbModel user)
        {
            using (var context = _userDataContextFactory.GetUserDataContext())
            {
                var userDb = context.Users.SingleOrDefault(x => x.Id.Equals(user.Id));
                userDb.Nick = user.Nick;
                userDb.Email = user.Email;
                context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            using (var context = _userDataContextFactory.GetUserDataContext())
            {
                var user = context.Users.SingleOrDefault(x => x.Id.Equals(id));
                if (null != user)
                    context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public List<UserDbModel> ReadUsers()
        {
            using (var context = _userDataContextFactory.GetUserDataContext())
                return context.Users.ToList();
        }

        public UserDbModel ReadUser(int id)
        {
            using (var context = _userDataContextFactory.GetUserDataContext())
                return context.Users.SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
