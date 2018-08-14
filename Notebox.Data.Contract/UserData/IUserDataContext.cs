using System;
using Microsoft.EntityFrameworkCore;
using Notebox.DBModels.UserDataModel;

namespace Notebox.Data.Contract.UserData
{
    public interface IUserDataContext : IDisposable
    {
        DbSet<UserDbModel> Users { get; set; }
        int SaveChanges();
    }
}
