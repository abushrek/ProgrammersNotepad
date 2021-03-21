using System;
using System.Collections.ObjectModel;
using System.Threading;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Models.List;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.Annotations.ListViewModels
{
    public class NoteTypeListViewModel:BaseListViewModel<NoteTypeListModel>
    {
        private Guid _currentUserId;
        private NoteTypeListModel _selectedType;
        public new INoteTypeFacade Facade { get; }

        public NoteTypeListModel SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                Mediator.Send(new SelectedNoteTypeChangedMessage()
                {
                    Model = value
                });
                OnPropertyChanged();
            }
        }

        public NoteTypeListViewModel(INoteTypeFacade facade, IMediator mediator) : base(facade, mediator)
        {
            Facade = facade;
            Mediator.Register<LoginMessage>(Login);
            Load();
        }

        private void Login(LoginMessage obj)
        {
            if (Thread.CurrentPrincipal is AuthenticationPrincipal.TCAPrincipal principal)
                _currentUserId = principal.Identity.Id;
            Load();
        }

        public sealed override void Load()
        {
            if(_currentUserId != Guid.Empty)
                Models = new ObservableCollection<NoteTypeListModel>(Facade.GetAllNoteTypesByUserId(_currentUserId));
            base.Load();
        }
    }
}