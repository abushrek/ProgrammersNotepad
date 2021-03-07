using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.ViewModels.Annotations.Interfaces;

namespace ProgrammersNotepad.ViewModels.BaseClasses
{
    public abstract class BaseDatabaseViewModel<TModel>:BaseViewModel, IDatabaseViewModel<TModel> where TModel : IModel, new()
    {
        public IFacade<TModel> Facade { get; protected set; }

        protected BaseDatabaseViewModel(IFacade<TModel> facade, IMediator mediator) : base(mediator)
        {
            Facade = facade;
        }

    }
}