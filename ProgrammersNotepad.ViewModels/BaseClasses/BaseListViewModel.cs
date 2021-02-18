using System.Collections.ObjectModel;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.ViewModels.BaseClasses
{
    public abstract class BaseListViewModel<TModel> : BaseViewModel<TModel> where TModel : IModel, new()
    {
        public ObservableCollection<TModel> Users
        {
            get;
            protected set;
        }

        protected BaseListViewModel(IFacade<TModel> facade) : base(facade)
        {
            Users = new ObservableCollection<TModel>();
        }
    }
}