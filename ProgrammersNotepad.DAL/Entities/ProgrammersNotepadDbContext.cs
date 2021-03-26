using System;
using Microsoft.EntityFrameworkCore;

namespace ProgrammersNotepad.DAL.Entities
{
    public class ProgrammersNotepadDbContext:Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<NoteTypeEntity> NoteTypeSet { get; set; }
        public DbSet<NoteEntity> NoteSet { get; set; }
        public DbSet<UserEntity> UserSet { get; set; }
        public DbSet<ImageEntity> ImageSet { get; set; }

        public ProgrammersNotepadDbContext()
        {
            
        }

        public ProgrammersNotepadDbContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasMany(s => s.NoteTypeCollection).WithOne(s => s.User);
            modelBuilder.Entity<NoteTypeEntity>().HasMany(s=>s.NoteCollection).WithOne(s=>s.NoteType);
            modelBuilder.Entity<NoteEntity>().HasMany(s=>s.ImageCollection).WithOne(s=>s.Note);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;Database=ProgrammersNotepadDb;MultipleActiveResultSets=True;Integrated Security=True;", builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);

                });
        }
    }
}