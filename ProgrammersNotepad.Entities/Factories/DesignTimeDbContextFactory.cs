using Microsoft.EntityFrameworkCore.Design;

namespace ProgrammersNotepad.Entities.Factories
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProgrammersNotepadDbContext>
    {
        public ProgrammersNotepadDbContext CreateDbContext(string[] args)
            => new SqlServerDbContextFactory(@"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = MigrationDb;MultipleActiveResultSets = True;Integrated Security = True; ")
                .CreateDbContext();
    }
}