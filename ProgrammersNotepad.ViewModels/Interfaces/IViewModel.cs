using ProgrammersNotepad.BL.Services.Interfaces;

namespace ProgrammersNotepad.ViewModels.Annotations.Interfaces
{
    public interface IViewModel
    {
        IMediator Mediator { get; }
        void Load();
    }
}