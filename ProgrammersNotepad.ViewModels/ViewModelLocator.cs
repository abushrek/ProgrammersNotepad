using ProgrammersNotepad.API;
using ProgrammersNotepad.ViewModels.Annotations.ListViewModels;
using ProgrammersNotepad.ViewModels.DetailViewModels;

namespace ProgrammersNotepad.ViewModels
{
    public class ViewModelLocator
    {
        public UserDetailViewModel UserDetailViewModel => InitializerOfObjects.GetService<UserDetailViewModel>();
        public UserListViewModel UserListViewModel => InitializerOfObjects.GetService<UserListViewModel>();
        public LoginViewModel LoginViewModel => InitializerOfObjects.GetService<LoginViewModel>();

    }
}