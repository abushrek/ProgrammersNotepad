using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class LanguageRepository:BaseRepository<LanguageEntity>
    {
        public LanguageRepository(ProgrammersNotepadDbContext dbContext) : base(dbContext.LanguageSet, dbContext)
        {
        }
    }
}