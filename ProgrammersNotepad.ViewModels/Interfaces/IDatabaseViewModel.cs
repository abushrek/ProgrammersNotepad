using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.ViewModels.Annotations.Interfaces
{
    public interface IDatabaseViewModel<TModel>:IViewModel where TModel:IModel, new()
    {
        IFacade<TModel> Facade { get; }
    }
}