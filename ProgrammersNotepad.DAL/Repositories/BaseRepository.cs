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
        protected IDbContextFactory<ProgrammersNotepadDbContext> DbContextFactory;

        protected BaseRepository(DbSet<TEntity> setOfEntities, IDbContextFactory<ProgrammersNotepadDbContext> dbContextFactory)
        {
            SetOfEntities = setOfEntities;
            DbContextFactory = dbContextFactory;
        }

        public virtual IList<TEntity> GetAll()
        {
            return SetOfEntities.ToList();
        }

        public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken token = default)
        {
            return await SetOfEntities.ToListAsync(cancellationToken: token);
        }

        public virtual TEntity GetById(Guid id)
        {
            return SetOfEntities.FirstOrDefault(s => s.Id == id);
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return await SetOfEntities.FirstOrDefaultAsync(s => s.Id == id, cancellationToken: token);
        }

        public virtual bool Remove(Guid id)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                TEntity entity = GetById(id);
                if (entity == null)
                    return false;
                if (SetOfEntities.Remove(entity) != null)
                {
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public virtual async Task<bool> RemoveAsync(Guid id, CancellationToken token = default)
        {
            return await Task.Run(() => Remove(id), token);
        }

        public virtual TEntity Add(TEntity entity)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                if (entity == null)
                    throw new ArgumentNullException();
                if (SetOfEntities.Add(entity) != null)
                {
                    dbContext.SaveChanges();
                    return entity;
                }
            }
            return default;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken token = default)
        {
            return await Task.Run(() => Add(entity), token);
        }

        public virtual void Update(TEntity entity)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                if (entity == null)
                    throw new ArgumentNullException();
                if (SetOfEntities.All(s => s.Id != entity.Id))
                    SetOfEntities.Add(entity);
                TEntity entry = SetOfEntities.FirstOrDefault(s => s.Id == entity.Id);
                if (entry != null)
                {
                    dbContext.Entry<TEntity>(entry).CurrentValues.SetValues(entity);
                    dbContext.SaveChanges();
                }
            }
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken token = default)
        {
            await Task.Run(() => Update(entity), token);
        }

        public virtual bool Exists(TEntity entity)
        {
            return SetOfEntities.Any(s => s.Equals(entity));
        }

        public virtual async Task<bool> ExistsAsync(TEntity entity)
        {
            return await SetOfEntities.AnyAsync(s => s.Equals(entity));
        }
    }
}