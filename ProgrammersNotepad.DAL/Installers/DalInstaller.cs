using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories;
using ProgrammersNotepad.DAL.Repositories.Interfaces;

namespace ProgrammersNotepad.DAL.Installers
{
    public class DalInstaller:BaseDalInstaller
    {
        public override void Install(IServiceCollection serviceCollection)
        {
            base.Install(serviceCollection);
            serviceCollection.AddTransient<IRepository<NoteTypeEntity>, NoteTypeRepository>();
            serviceCollection.AddTransient<IRepository<NoteEntity>, NoteRepository>();
            serviceCollection.AddTransient<IUserRepository<UserEntity>, UserRepository>();
        }
    }
}