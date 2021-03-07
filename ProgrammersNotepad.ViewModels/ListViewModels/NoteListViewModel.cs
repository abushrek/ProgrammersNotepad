using System;
using System.Collections.ObjectModel;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Models.List;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.Annotations.ListViewModels
{
    public class NoteListViewModel: BaseListViewModel<NoteListModel>
    {
        private Guid _selectedNoteType;
        private NoteListModel _selectedNote;
        public new INoteFacade Facade { get; protected set; }

        public NoteListModel SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                Mediator.Send(new SelectedNoteChangedMessage()
                {
                    SelectedNoteId = value.Id
                });
                OnPropertyChanged();
            }
        }

        public NoteListViewModel(INoteFacade facade, IMediator mediator) : base(facade, mediator)
        {
            Facade = facade;
            Mediator.Register<SelectedNoteTypeChangedMessage>(OnSelectedNoteTypeChanged);
        }

        private void OnSelectedNoteTypeChanged(SelectedNoteTypeChangedMessage obj)
        {
            _selectedNoteType = obj.Model.Id;
            Load();
        }

        public override void Load()
        {
            Models = new ObservableCollection<NoteListModel>(Facade.GetAllNotesByNoteType(_selectedNoteType));
            base.Load();
        }
    }
}