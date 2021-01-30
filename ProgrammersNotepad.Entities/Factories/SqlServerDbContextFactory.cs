using Microsoft.EntityFrameworkCore;

namespace ProgrammersNotepad.Entities.Factories
{
    public class SqlServerDbContextFactory : IDbContextFactory<ProgrammersNotepadDbContext>
    {
        private readonly string _connectionString;

        public SqlServerDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ProgrammersNotepadDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProgrammersNotepadDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            return new ProgrammersNotepadDbContext(optionsBuilder.Options);
        }
    }
}