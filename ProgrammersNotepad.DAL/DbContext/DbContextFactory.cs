using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.DbContext
{
    public class DbContextFactory : IDbContextFactory<ProgrammersNotepadDbContext>
    {
        public ProgrammersNotepadDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProgrammersNotepadDbContext>();
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=ProgrammersNotepadDb;MultipleActiveResultSets=True;Integrated Security=True;");
            optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));
            return new ProgrammersNotepadDbContext(optionsBuilder.Options);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{

        //    options.UseLazyLoadingProxies().UseSqlServer(
        //        "Server=(localdb)\\mssqllocaldb;Database=ProgrammersNotepadDb;Trusted_Connection=True;", builder =>
        //        {
        //            builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        //        });
        //}
    }
}