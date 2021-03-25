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
        public ImageRepository(ProgrammersNotepadDbContext dbContext) : base(dbContext.ImageSet, dbContext)
        {
        }

        public IEnumerable<ImageEntity> GetAllByNoteId(Guid id)
        {
            return SetOfEntities.Where(s => s.Note.Id == id);
        }

        public async Task<IEnumerable<ImageEntity>> GetAllByNoteIdAsync(Guid id)
        {
            return await Task.Run(() => GetAllByNoteId(id));
        }
    }
}