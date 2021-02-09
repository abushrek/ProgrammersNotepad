using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class UserRepository:BaseRepository<UserEntity>
    {
        public UserRepository(ProgrammersNotepadDbContext dbContext) : base(dbContext.UserSet, dbContext)
        {
        }
    }
}