using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.DAL.Installers.Interfaces;
using ProgrammersNotepad.ViewModels.DetailViewModels;

namespace ProgrammersNotepad.ViewModels.Installer
{
    public class ViewModelsInstaller:IInstaller
    {
        public void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UserDetailViewModel>();
        }
    }
}