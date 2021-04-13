﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProgrammersNotepad.DAL.DbContext;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class ImageRepository:BaseRepository<ImageEntity>, IImageRepository<ImageEntity>
    {
        public ImageRepository(IDbContextFactory<ProgrammersNotepadDbContext> dbContextFactory) : base(dbContextFactory)
        {

        }

        public override ImageEntity Add(ImageEntity entity)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                if (entity == null)
                    throw new ArgumentNullException();
                if (!Exists(entity))
                    if (dbContext.GetDatabaseByType<ImageEntity>().Add(entity) != null)
                    {
                        if (entity.Note != null)
                        {
                            dbContext.Entry(entity.Note).State = EntityState.Unchanged;
                        }
                        dbContext.SaveChanges();
                        return entity;
                    }
            }
            return null;
        }

        public IEnumerable<ImageEntity> GetAllByNoteId(Guid id)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                return dbContext.ImageSet.Where(s => s.Note.Id == id).ToList();
            }
        }

        public async Task<IEnumerable<ImageEntity>> GetAllByNoteIdAsync(Guid id)
        {
            return await Task.Run(() => GetAllByNoteId(id));
        }
    }
}