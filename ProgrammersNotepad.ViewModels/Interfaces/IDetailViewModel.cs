using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.ViewModels.Annotations.Interfaces
{
    public interface IDetailViewModel<TModel>: IDatabaseViewModel<TModel> where TModel : IModel, new()
    {
        TModel Model { get; set; }
    }
}