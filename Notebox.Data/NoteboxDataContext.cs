using Microsoft.EntityFrameworkCore;
using Notebox.UserDBModel.UserDataModel;

namespace Notebox.Data
{
    public class NoteboxDataContext: DbContext
    {
        public DbSet<UserDbModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = SQL_PC; Database = NoteboxData; User Id=sa; Password=Omgwtflol1");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
