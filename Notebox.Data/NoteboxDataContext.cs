using Microsoft.EntityFrameworkCore;
using Notebox.Data.Contract.MajorData;
using Notebox.Data.Contract.UserData;
using Notebox.DBModels.MajorDataModel;
using Notebox.DBModels.UserDataModel;

namespace Notebox.Data
{
    public class NoteboxDataContext: DbContext, IUserDataContext, IMajorDataContext
    {
        public DbSet<UserDbModel> Users { get; set; }
        public DbSet<MajorDbModel> Majors { get; set; }
        public DbSet<MajorToUserDbModel> MajorsToUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = SQL_PC; Database = NoteboxData; User Id=sa; Password=Omgwtflol1");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MajorToUserDbModel>()
                .HasKey(k => new {k.MajorId, k.UserId});

            modelBuilder.Entity<UserDbModel>()
                .HasIndex(u => new {u.Nick})
                .IsUnique(true);

            modelBuilder.Entity<UserDbModel>()
                .HasIndex(u => new { u.Email })
                .IsUnique(true);
        }
    }
}
