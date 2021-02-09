using Microsoft.EntityFrameworkCore;

namespace ProgrammersNotepad.DAL.Entities
{
    public class ProgrammersNotepadDbContext:DbContext
    {
        public DbSet<LanguageEntity> LanguageSet { get; set; }
        public DbSet<NoteEntity> NoteSet { get; set; }
        public DbSet<UserEntity> UserSet { get; set; }
        public DbSet<LanguageNoteEntity> LanguageNoteSet { get; set; }

        public ProgrammersNotepadDbContext()
        {
            
        }

        public ProgrammersNotepadDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LanguageNoteEntity>().HasOne(i => i.Language);
            modelBuilder.Entity<UserEntity>().HasMany(i => i.ListOfNotes);
        }
    }
}