using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.ViewModels.Annotations;
using ProgrammersNotepad.ViewModels.Annotations.Interfaces;

namespace ProgrammersNotepad.ViewModels.BaseClasses
{
    public abstract class BaseViewModel :IViewModel,INotifyPropertyChanged
    {
        public IMediator Mediator { get; protected set; }
        protected BaseViewModel(IMediator mediator)
        {
            Mediator = mediator;
        }


        public virtual void Load()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}