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
        protected IDbContextFactory<ProgrammersNotepadDbContext> DbContextFactory;

        protected BaseRepository(IDbContextFactory<ProgrammersNotepadDbContext> dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                IEnumerable<TEntity> baseEntities = dbContext.GetDatabaseByType<TEntity>().ToList();
                return baseEntities;
            }
        }

        public virtual async Task<List<TEntity>> GetAllAsync(CancellationToken token = default)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                return await dbContext.GetDatabaseByType<TEntity>().ToListAsync(cancellationToken: token);
            }
            
        }

        public virtual TEntity GetById(Guid id)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                return dbContext.GetDatabaseByType<TEntity>().FirstOrDefault(s => s.Id == id);
            }
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                return await dbContext.GetDatabaseByType<TEntity>().FirstOrDefaultAsync(s => s.Id == id, cancellationToken: token);
            }
        }

        public virtual bool Remove(Guid id)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                TEntity entity = GetById(id);
                if (entity == null)
                    return false;
                if (dbContext.GetDatabaseByType<TEntity>().Remove(entity) != null)
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
                if(!Exists(entity))
                    if (dbContext.GetDatabaseByType<TEntity>().Add(entity) != null)
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
                if (dbContext.GetDatabaseByType<TEntity>().All(s => s.Id != entity.Id))
                    dbContext.GetDatabaseByType<TEntity>().Add(entity);
                TEntity entry = dbContext.GetDatabaseByType<TEntity>().FirstOrDefault(s => s.Id == entity.Id);
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
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                return dbContext.GetDatabaseByType<TEntity>().Any(s => s.Equals(entity));
            }
        }

        public virtual async Task<bool> ExistsAsync(TEntity entity, CancellationToken token = default)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                return await dbContext.GetDatabaseByType<TEntity>().AnyAsync(s => s.Equals(entity) || (entity != null && s.Id == entity.Id), token);
            }
        }
    }
}