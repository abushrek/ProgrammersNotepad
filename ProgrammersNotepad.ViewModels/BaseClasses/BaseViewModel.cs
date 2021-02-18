using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.ViewModels.Annotations.Interfaces;

namespace ProgrammersNotepad.ViewModels.BaseClasses
{
    public abstract class BaseViewModel<TModel> :IViewModel where TModel:IModel,new()
    {
        protected IFacade<TModel> Facade;

        protected BaseViewModel(IFacade<TModel> facade)
        {
            Facade = facade;
        }

        public virtual void Load()
        {

        }
    }
}