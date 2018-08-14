using System;
using Microsoft.EntityFrameworkCore;
using Notebox.DBModels.MajorDataModel;

namespace Notebox.Data.Contract.MajorData
{
    public interface IMajorDataContext : IDisposable

    {
        DbSet<MajorDbModel> Majors { get; set; }
        DbSet<MajorToUserDbModel> MajorsToUsers { get; set; }
        int SaveChanges();
    }
}
