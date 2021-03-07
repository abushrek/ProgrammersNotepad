using System.Collections.ObjectModel;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.ViewModels.Annotations.Interfaces;

namespace ProgrammersNotepad.ViewModels.BaseClasses
{
    public abstract class BaseListViewModel<TModel> : BaseDatabaseViewModel<TModel>,IListViewModel<TModel> where TModel : IListModel, new()
    {
        private ObservableCollection<TModel> _models;

        public ObservableCollection<TModel> Models
        {
            get => _models;
            protected set
            {
                _models = value;
                OnPropertyChanged();
            }
        }

        protected BaseListViewModel(IFacade<TModel> facade, IMediator mediator) : base(facade, mediator)
        {
            Models = new ObservableCollection<TModel>();
        }
    }
}