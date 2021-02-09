using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IList<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync(CancellationToken token = default);
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id, CancellationToken token = default);
        void Remove(Guid id);
        Task RemoveAsync(Guid id, CancellationToken token = default);
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default);
        void Update(TEntity entity);
        Task UpdateAsync(TEntity entity, CancellationToken token = default);
    }
}