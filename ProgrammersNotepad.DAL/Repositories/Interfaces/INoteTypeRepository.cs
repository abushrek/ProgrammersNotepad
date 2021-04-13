using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Repositories.Interfaces
{
    public interface INoteTypeRepository<TEntity>: IRepository<TEntity> where TEntity : NoteTypeEntity
    {
        IEnumerable<TEntity> GetAllNoteTypesByUserId(Guid id);
        Task<IEnumerable<TEntity>> GetAllNoteTypesByUserIdAsync(Guid id, CancellationToken token = default);
        void ClearAllByUserId(Guid userId);
    }
}