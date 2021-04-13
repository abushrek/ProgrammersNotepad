﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class NoteTypeRepository:BaseRepository<NoteTypeEntity>, INoteTypeRepository<NoteTypeEntity>
    {
        public NoteTypeRepository(IDbContextFactory<ProgrammersNotepadDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public IEnumerable<NoteTypeEntity> GetAllNoteTypesByUserId(Guid id)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                IEnumerable<NoteTypeEntity> baseEntities = dbContext.GetDatabaseByType<NoteTypeEntity>().Where(s=>s.User != null &&  s.User.Id == id).ToList();
                return baseEntities;
            }
        }

        public async Task<IEnumerable<NoteTypeEntity>> GetAllNoteTypesByUserIdAsync(Guid id, CancellationToken token = default)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                IEnumerable<NoteTypeEntity> baseEntities = await dbContext.GetDatabaseByType<NoteTypeEntity>().Where(s => s.User != null && s.User.Id == id).ToListAsync(token);
                return baseEntities;
            }
        }

        public void ClearAllByUserId(Guid userId)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                foreach (NoteTypeEntity typeEntity in GetAllNoteTypesByUserId(userId))
                {
                    dbContext.GetDatabaseByType<NoteTypeEntity>().Remove(typeEntity);
                }
                dbContext.SaveChanges();
            }
        }
    }
}