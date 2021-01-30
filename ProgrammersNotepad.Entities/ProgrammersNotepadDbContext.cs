using Microsoft.EntityFrameworkCore;
using ProgrammersNotepad.Entities.Interfaces;

namespace ProgrammersNotepad.Entities
{
    public class ProgrammersNotepadDbContext:DbContext
    {
        private DbSet<LanguageEntity> Languages { get; set; }
        private DbSet<BaseUserEntity> Users { get; set; }
        private DbSet<LanguageNoteEntity> Entities { get; set; }

        public ProgrammersNotepadDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageNoteEntity>().HasOne(i => i.Language);
            modelBuilder.Entity<BaseUserEntity>().HasMany(i => i.ListOfNotes);
        }
    }
}