using Microsoft.Extensions.DependencyInjection;
using ProgrammersNotepad.DAL.Installers.Interfaces;
using ProgrammersNotepad.ViewModels.Annotations.ListViewModels;
using ProgrammersNotepad.ViewModels.DetailViewModels;

namespace ProgrammersNotepad.ViewModels.Installer
{
    public class ViewModelsInstaller:BaseViewModelsInstaller
    {
        public override void Install(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<UserDetailViewModel>();
            serviceCollection.AddTransient<UserListViewModel>();
            serviceCollection.AddTransient<LoginViewModel>();
        }
    }
}