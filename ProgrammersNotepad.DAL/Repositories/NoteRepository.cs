using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class NoteRepository:BaseRepository<NoteEntity>
    {
        public NoteRepository(ProgrammersNotepadDbContext dbContext) : base(dbContext.NoteSet, dbContext)
        {
        }

    }
}