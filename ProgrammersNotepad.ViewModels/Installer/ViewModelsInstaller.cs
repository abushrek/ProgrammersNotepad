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
            serviceCollection.AddTransient<MainWindowViewModel>();
            serviceCollection.AddTransient<UserProfileViewModel>();
            serviceCollection.AddTransient<NoteTypeListViewModel>();
            serviceCollection.AddTransient<NoteListViewModel>();
            serviceCollection.AddTransient<NoteDetailViewModel>();
            serviceCollection.AddTransient<RegisterViewModel>();
            serviceCollection.AddTransient<ImageDetailViewModel>();
        }
    }
}