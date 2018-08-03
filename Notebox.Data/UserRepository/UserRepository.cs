using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Notebox.UserDBModel.UserDataModel;

namespace Notebox.Data.UserRepository
{
    public class UserRepository: IUserRepository
    {

        public UserDbModel CreateUser(UserDbModel user)
        {
            using (var context = new NoteboxDataContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return context.Users.SingleOrDefault(x => x.Nick.Equals(user.Nick));
            }
        }

        public void UpdateUser(UserDbModel user)
        {
            using (var context = new NoteboxDataContext())
            {
                var userDb = context.Users.SingleOrDefault(x => x.Id.Equals(user.Id));
                userDb.Nick = user.Nick;
                userDb.Email = user.Email;
                context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            using (var context = new NoteboxDataContext())
            {
                var user = context.Users.SingleOrDefault(x => x.Id.Equals(id));
                if (null != user)
                    context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public List<UserDbModel> ReadUsers()
        {
            using (var context = new NoteboxDataContext())
                return context.Users.ToList();
        }

        public UserDbModel ReadUser(int id)
        {
            using (var context = new NoteboxDataContext())
                return context.Users.SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}
