using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.ViewModels.Annotations;

namespace ProgrammersNotepad.ViewModels.BaseClasses
{
    public abstract class BaseDetailViewModel<TModel>: BaseViewModel<TModel>, INotifyPropertyChanged where TModel : IModel, new()
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

        protected BaseDetailViewModel(IDetailFacade<TModel> facade) : base(facade)
        {
            Model = new TModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}