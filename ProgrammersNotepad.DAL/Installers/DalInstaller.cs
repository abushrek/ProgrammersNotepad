using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Installers.Interfaces;
using ProgrammersNotepad.DAL.Repositories;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.DAL.Installers
{
    public class DalInstaller:BaseDalInstaller
    {
        public override void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProgrammersNotepadDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProgrammersNotepadDb;Trusted_Connection=True;", builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                }));
            serviceCollection.AddTransient<IRepository<NoteTypeEntity>, NoteTypeRepository>();
            serviceCollection.AddTransient<IRepository<NoteEntity>, NoteRepository>();
            serviceCollection.AddTransient<IUserRepository<UserEntity>, UserRepository>();
        }
    }
}