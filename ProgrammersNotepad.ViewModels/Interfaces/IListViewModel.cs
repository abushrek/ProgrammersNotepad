using System.Collections.ObjectModel;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.ViewModels.Annotations.Interfaces
{
    public interface IListViewModel<TModel>:IDatabaseViewModel<TModel> where TModel : IModel, new()
    {
        ObservableCollection<TModel> Models { get; }
    }
}