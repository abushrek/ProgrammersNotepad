using Microsoft.EntityFrameworkCore.Design;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProgrammersNotepadDbContext>
    {
        public ProgrammersNotepadDbContext CreateDbContext(string[] args)
            => new SqlServerDbContextFactory(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=ProgrammersNotepadDb;Trusted_Connection=True;")
                .CreateDbContext();
    }
}