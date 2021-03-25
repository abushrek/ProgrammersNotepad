using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Repositories.Interfaces
{
    public interface IImageRepository<TEntity>: IRepository<TEntity> where TEntity : ImageEntity
    {
        IEnumerable<TEntity> GetAllByNoteId(Guid id);
        Task<IEnumerable<TEntity>> GetAllByNoteIdAsync(Guid id);
    }
}