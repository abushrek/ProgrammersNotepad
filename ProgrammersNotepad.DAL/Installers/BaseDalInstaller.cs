using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.DAL.Installers.Interfaces;

namespace ProgrammersNotepad.DAL.Installers
{
    public abstract class BaseDalInstaller:IInstaller
    {
        public virtual void Install(IServiceCollection serviceCollection)
        {

        }
    }
}