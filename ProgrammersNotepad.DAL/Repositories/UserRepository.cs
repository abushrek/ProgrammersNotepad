using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class UserRepository:BaseRepository<UserEntity>, IUserRepository<UserEntity>
    {
        public UserRepository(ProgrammersNotepadDbContext dbContext) : base(dbContext.UserSet, dbContext)
        {
        }

        public UserEntity GetByUserName(string username)
        {
            return SetOfEntities.FirstOrDefault(s => s.Username == username);
        }

        public async Task<UserEntity> GetByUserNameAsync(string username)
        {
            return await SetOfEntities.FirstOrDefaultAsync(s => s.Username == username);
        }

        public string GetPasswordByUserName(string username)
        {
            return SetOfEntities.FirstOrDefault(s => s.Username == username)?.Password;
        }

        public async Task<string> GetPasswordByUserNameAsync(string username)
        {
            return (await SetOfEntities.FirstOrDefaultAsync(s => s.Username == username))?.Password;
        }

        public bool Exists(string username)
        {
            return SetOfEntities.Any(s => s.Username == username);
        }

        public async Task<bool> ExistsAsync(string username)
        {
            return await SetOfEntities.AnyAsync(s => s.Username == username);
        }
    }
}