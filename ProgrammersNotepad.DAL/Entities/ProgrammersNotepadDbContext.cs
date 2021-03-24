using System;
using Microsoft.EntityFrameworkCore;

namespace ProgrammersNotepad.DAL.Entities
{
    public class ProgrammersNotepadDbContext:DbContext
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
            modelBuilder.Entity<NoteEntity>().HasMany(i => i.ImagesAsBytes);
            modelBuilder.Entity<NoteTypeEntity>().HasMany(i => i.ListOfEntities);
            modelBuilder.Entity<UserEntity>().HasMany(i => i.ListOfNoteTypes).WithOne(s=>s.User).OnDelete(DeleteBehavior.Cascade);

            //add-migration Initial
            //remove-migration
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            
            options.UseLazyLoadingProxies().UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=ProgrammersNotepadDb;Trusted_Connection=True;", builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);

                });
        }
    }
}