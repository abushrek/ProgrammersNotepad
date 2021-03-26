using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class ImageRepository:BaseRepository<ImageEntity>, IImageRepository<ImageEntity>
    {
        public ImageRepository(IDbContextFactory<ProgrammersNotepadDbContext> dbContextFactory) : base(dbContextFactory.CreateDbContext().ImageSet,dbContextFactory)
        {
        }

        public override ImageEntity Add(ImageEntity entity)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                if (entity == null)
                    throw new ArgumentNullException();
                if (dbContext.ImageSet.Add(entity) != null)
                {
                    dbContext.SaveChanges();
                    return entity;
                }
                return default;
            }
        }

        public override IList<ImageEntity> GetAll()
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                return dbContext.ImageSet.ToList();
            }
        }

        public override ImageEntity GetById(Guid id)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                return dbContext.ImageSet.FirstOrDefault(s=>s.Id == id);
            }
        }

        public override bool Remove(Guid id)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                ImageEntity entity = GetById(id);
                if (entity == null)
                    return false;
                if (dbContext.ImageSet.Remove(entity) != null)
                {
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<ImageEntity> GetAllByNoteId(Guid id)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                return dbContext.ImageSet.Where(s => s.Note.Id == id);
            }
        }

        public async Task<IEnumerable<ImageEntity>> GetAllByNoteIdAsync(Guid id)
        {
            return await Task.Run(() => GetAllByNoteId(id));
        }
    }
}