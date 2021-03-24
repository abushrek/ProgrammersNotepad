using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbSet<TEntity> SetOfEntities;
        protected DbContext DbContext;

        protected BaseRepository(DbSet<TEntity> setOfEntities, DbContext dbContext)
        {
            SetOfEntities = setOfEntities;
            DbContext = dbContext;
        }

        public virtual IList<TEntity> GetAll()
        {
            return SetOfEntities.ToList();
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken token = default)
        {
            return await SetOfEntities.ToListAsync(cancellationToken: token);
        }

        public virtual TEntity GetById(Guid id)
        {
            return SetOfEntities.FirstOrDefault(s => s.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return await SetOfEntities.FirstOrDefaultAsync(s => s.Id == id, cancellationToken: token);
        }

        public bool Remove(Guid id)
        {
            TEntity entity = GetById(id);
            if (entity == null)
                return false;
            if (SetOfEntities.Remove(entity) != null)
            {
                DbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveAsync(Guid id, CancellationToken token = default)
        {
            return await Task.Run(() => Remove(id), token);
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            if (SetOfEntities.Add(entity) != null)
            {
                DbContext.SaveChanges();
                return entity;
            }
            return default;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default)
        {
            return await Task.Run(() => Add(entity), token);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            if (SetOfEntities.All(s => s.Id != entity.Id))
                SetOfEntities.Add(entity);
            TEntity entry = SetOfEntities.FirstOrDefault(s=> s.Id == entity.Id);
            if(entry != null)
            {
                DbContext.Entry<TEntity>(entry).CurrentValues.SetValues(entity);
                DbContext.SaveChanges();
            }
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken token = default)
        {
            await Task.Run(() => Update(entity), token);
        }

        public bool Exists(TEntity entity)
        {
            return SetOfEntities.Any(s => s.Equals(entity));
        }

        public async Task<bool> ExistsAsync(TEntity entity)
        {
            return await SetOfEntities.AnyAsync(s => s.Equals(entity));
        }
    }
}