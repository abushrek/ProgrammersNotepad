using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class LanguageNoteRepository:BaseRepository<LanguageNoteEntity>
    {
        public LanguageNoteRepository(ProgrammersNotepadDbContext dbContext) : base(dbContext.LanguageNoteSet, dbContext)
        {
        }
    }
}