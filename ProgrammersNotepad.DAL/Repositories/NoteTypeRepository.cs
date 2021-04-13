using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class NoteTypeRepository:BaseRepository<NoteTypeEntity>
    {
        public NoteTypeRepository(IDbContextFactory<ProgrammersNotepadDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}