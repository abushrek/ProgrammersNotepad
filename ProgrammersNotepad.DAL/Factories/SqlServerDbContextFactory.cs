using System;
using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Factories
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
            optionsBuilder.UseSqlServer(_connectionString, builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            return new ProgrammersNotepadDbContext(optionsBuilder.Options);
        }
    }
}