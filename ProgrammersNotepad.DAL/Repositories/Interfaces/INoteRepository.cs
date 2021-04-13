using System;
using System.Collections.Generic;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Repositories.Interfaces
{
    public interface INoteRepository<TEntity> : IRepository<TEntity> where TEntity : NoteEntity
    {
        IEnumerable<TEntity> GetAllNotesByNoteType(Guid typeId);
    }
}