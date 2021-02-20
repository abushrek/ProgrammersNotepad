using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.DAL.Installers.Interfaces;

namespace ProgrammersNotepad.ViewModels.Installer
{
    public abstract class BaseViewModelsInstaller : IInstaller
    {
        public virtual void Install(IServiceCollection serviceCollection)
        {

        }
    }
}