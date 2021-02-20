using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.DAL.Installers.Interfaces;

namespace ProgrammersNotepad.BL.Installers
{
    public abstract class BaseBlInstaller:IInstaller
    {
        public virtual void Install(IServiceCollection serviceCollection)
        {
            
        }
    }
}