using ProgrammersNotepad.ViewModels.DetailViewModels;

namespace ProgrammersNotepad.ViewModels
{
    public class ViewModelLocator
    {
        public UserDetailViewModel UserDetailViewModel => InitializerOfObjects.GetService<UserDetailViewModel>();

    }
}