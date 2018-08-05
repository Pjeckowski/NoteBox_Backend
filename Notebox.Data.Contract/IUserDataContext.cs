using System;
using Microsoft.EntityFrameworkCore;
using Notebox.UserDBModel.UserDataModel;

namespace Notebox.Data.Contract
{
    public interface IUserDataContext : IDisposable
    {
        DbSet<UserDbModel> Users { get; set; }

        int SaveChanges();
    }
}
