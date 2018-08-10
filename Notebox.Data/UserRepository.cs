﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<UserDbModel> CreateUserAsync(UserDbModel user)
        {
            using (var context = _userDataContextFactory.GetUserDataContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
                return await context.Users.SingleOrDefaultAsync(x => x.Nick.Equals(user.Nick));
            }
        }

        public async Task UpdateUserAsync(UserDbModel user)
        {
            using (var context = _userDataContextFactory.GetUserDataContext())
            {
                var userDb = await context.Users.SingleOrDefaultAsync(x => x.Id.Equals(user.Id));
                userDb.Nick = user.Nick;
                userDb.Email = user.Email;
                context.SaveChanges();
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            using (var context = _userDataContextFactory.GetUserDataContext())
            {
                var user = await context.Users.SingleOrDefaultAsync(x => x.Id.Equals(id));
                if (null != user)
                    context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public async Task<List<UserDbModel>> ReadUsersAsync()
        {
            using (var context = _userDataContextFactory.GetUserDataContext())
                return await context.Users.ToListAsync();
        }

        public async Task<UserDbModel> ReadUserAsync(int id)
        {
            using (var context = _userDataContextFactory.GetUserDataContext())
                return await context.Users.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
