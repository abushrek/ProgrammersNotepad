using System;
using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Seed
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = CreateDbContext())
            {
                ClearDatabase(dbContext);
                SeedData(dbContext);
            }
        }

        private static void SeedData(ProgrammersNotepadDbContext dbContext)
        {
            var user = new UserEntity
            {
                Id = new Guid("7f7cbc8d-399b-435a-b2d9-b6fb803c8e1a"),
                Username = "john.doe",
                Password = "pass",
                Email = "john.doe@example.com",
            };
            dbContext.Add(user);

            var user2 = new UserEntity
            {
                Id = new Guid("7f7cbc8d-399b-435a-b2d9-b6fb803c8e8a"),
                Username = "alice.cooper",
                Password = "pass",
                Email = "alice.cooper@example.com",
            };
            dbContext.Add(user2);

            dbContext.SaveChanges();
        }

        private static void ClearDatabase(ProgrammersNotepadDbContext dbContext)
        {
            dbContext.RemoveRange(dbContext.UserSet);
            dbContext.RemoveRange(dbContext.NoteSet);
            dbContext.RemoveRange(dbContext.LanguageSet);
            dbContext.RemoveRange(dbContext.LanguageNoteSet);
            dbContext.SaveChanges();
        }

        private static ProgrammersNotepadDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ProgrammersNotepadDbContext>();
            try
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\mssqllocaldb;Database=ProgrammersNotepadDb;Trusted_Connection=True;");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return new ProgrammersNotepadDbContext(optionsBuilder.Options);
        }
    }
}
