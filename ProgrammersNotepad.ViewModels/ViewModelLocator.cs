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
        public MainWindowViewModel MainWindowViewModel => InitializerOfObjects.GetService<MainWindowViewModel>();
        public UserProfileViewModel UserProfileViewModel => InitializerOfObjects.GetService<UserProfileViewModel>();
        public NoteTypeListViewModel NoteTypeListViewModel => InitializerOfObjects.GetService<NoteTypeListViewModel>();
        public NoteListViewModel NoteListViewModel => InitializerOfObjects.GetService<NoteListViewModel>();
        public NoteDetailViewModel NoteDetailViewModel => InitializerOfObjects.GetService<NoteDetailViewModel>();
        public RegisterViewModel RegisterViewModel => InitializerOfObjects.GetService<RegisterViewModel>();
        public ImageDetailViewModel ImageDetailViewModel => InitializerOfObjects.GetService<ImageDetailViewModel>();

    }
}