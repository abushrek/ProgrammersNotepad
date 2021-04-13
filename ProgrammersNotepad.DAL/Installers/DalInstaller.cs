using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.DAL.DbContext;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.DAL.Installers
{
    public class DalInstaller:BaseDalInstaller
    {
        public override void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDbContextFactory<ProgrammersNotepadDbContext>, DbContextFactory>();
            serviceCollection.AddTransient<IImageRepository<ImageEntity>, ImageRepository>();
            serviceCollection.AddTransient<INoteTypeRepository<NoteTypeEntity>, NoteTypeRepository>();
            serviceCollection.AddTransient<INoteRepository<NoteEntity>, NoteRepository>();
            serviceCollection.AddTransient<IUserRepository<UserEntity>, UserRepository>();
        }
    }
}