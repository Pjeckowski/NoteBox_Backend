using System;
using Microsoft.EntityFrameworkCore;
using Notebox.DBModels.MajorDataModel;
using Notebox.DBModels.SemesterDataModel;

namespace Notebox.Data.Contract.SemesterData
{
    public interface ISemesterDataContext : IDisposable

    {
        DbSet<SemesterDbModel> Semesters { get; set; }
        int SaveChanges();
    }
}
