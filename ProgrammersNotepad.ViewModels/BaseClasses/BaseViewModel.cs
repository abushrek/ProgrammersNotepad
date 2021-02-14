using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.ViewModels.BaseClasses
{
    public abstract class BaseViewModel<TModel> where TModel:IModel,new()
    {
        protected IFacade<TModel> Facade;

        protected BaseViewModel(IFacade<TModel> facade)
        {
            Facade = facade;
        }
    }
}