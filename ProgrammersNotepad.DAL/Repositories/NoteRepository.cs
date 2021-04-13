using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class NoteRepository:BaseRepository<NoteEntity>,INoteRepository<NoteEntity>
    {
        public NoteRepository(IDbContextFactory<ProgrammersNotepadDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public override NoteEntity Add(NoteEntity entity)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                if (entity == null)
                    throw new ArgumentNullException();
                if (!Exists(entity))
                    if (dbContext.GetDatabaseByType<NoteEntity>().Add(entity) != null)
                    {
                        if (entity.NoteType != null)
                        {
                            dbContext.Entry(entity.NoteType).State = EntityState.Unchanged;
                        }
                        dbContext.SaveChanges();
                        return entity;
                    }
            }
            return null;
        }

        public IEnumerable<NoteEntity> GetAllNotesByNoteType(Guid typeId)
        {
            using (ProgrammersNotepadDbContext dbContext = DbContextFactory.CreateDbContext())
            {
                IEnumerable<NoteEntity> baseEntities = dbContext.GetDatabaseByType<NoteEntity>().Where(s =>s.NoteType != null && s.NoteType.Id == typeId).ToList();
                return baseEntities;
            }
        }
    }
}