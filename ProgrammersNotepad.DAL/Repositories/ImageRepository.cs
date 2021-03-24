using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.DAL.Repositories
{
    public class ImageRepository:BaseRepository<ImageEntity>
    {
        public ImageRepository(ProgrammersNotepadDbContext dbContext) : base(dbContext.ImageSet, dbContext)
        {
        }
    }
}