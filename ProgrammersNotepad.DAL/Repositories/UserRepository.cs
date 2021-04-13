using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class UserRepository:BaseRepository<UserEntity>, IUserRepository<UserEntity>
    {
        public UserRepository(IDbContextFactory<ProgrammersNotepadDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public UserEntity GetByUserName(string username)
        {
            using(ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
                return dbContext.GetDatabaseByType<UserEntity>().FirstOrDefault(s => s.Username == username);
        }

        public async Task<UserEntity> GetByUserNameAsync(string username)
        {
            using(ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
                return await dbContext.GetDatabaseByType<UserEntity>().FirstOrDefaultAsync(s => s.Username == username);
        }

        public string GetPasswordByUserName(string username)
        {
            using(ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
                return dbContext.GetDatabaseByType<UserEntity>().FirstOrDefault(s => s.Username == username)?.Password;
        }

        public async Task<string> GetPasswordByUserNameAsync(string username)
        {
            using(ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
                return (await dbContext.GetDatabaseByType<UserEntity>().FirstOrDefaultAsync(s => s.Username == username))?.Password;
        }

        public bool Exists(string username)
        {
            using(ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
                return dbContext.GetDatabaseByType<UserEntity>().Any(s => s.Username == username);
        }

        public async Task<bool> ExistsAsync(string username)
        {
            using(ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
                return await dbContext.GetDatabaseByType<UserEntity>().AnyAsync(s => s.Username == username);
        }
    }
}