using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.ViewModels.Annotations;
using ProgrammersNotepad.ViewModels.Annotations.Interfaces;

namespace ProgrammersNotepad.ViewModels.BaseClasses
{
    public abstract class BaseDetailViewModel<TModel>: BaseDatabaseViewModel<TModel>, IDetailViewModel<TModel> where TModel : IDetailModel, new()
    {
        private TModel _model;

        public TModel Model
        {
            get => _model;
            set
            {
                _model = value;
                OnPropertyChanged();
            }
        }

        protected new IDetailFacade<TModel> Facade;

        protected BaseDetailViewModel(IDetailFacade<TModel> facade, IMediator mediator) : base(facade, mediator)
        {
            Model = new TModel();
            Facade = facade;
        }
    }
}