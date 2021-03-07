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
        private readonly INoteFacade _noteFacade;

        public NoteListModel SelectedNote
        {
            get => _selectedNote;
            set
            {
                _selectedNote = value;
                Mediator.Send(new SelectedNoteChangedMessage()
                {
                    SelectedNoteId = value?.Id ?? Guid.Empty
                });
                OnPropertyChanged();
            }
        }

        public NoteListViewModel(INoteFacade noteFacade, IFacade<NoteListModel> facade, IMediator mediator) : base(facade, mediator)
        {
            _noteFacade = noteFacade;
            Mediator.Register<SelectedNoteTypeChangedMessage>(OnSelectedNoteTypeChanged);
        }

        private void OnSelectedNoteTypeChanged(SelectedNoteTypeChangedMessage obj)
        {
            if(obj.Model != null)
                _selectedNoteType = obj.Model.Id;
            else
                _selectedNoteType = Guid.Empty;
            Load();
        }

        public override void Load()
        {
            if (_selectedNoteType != Guid.Empty)
                Models = new ObservableCollection<NoteListModel>(_noteFacade.GetAllNotesByNoteType(_selectedNoteType));
            else
                Models = new ObservableCollection<NoteListModel>();
            base.Load();
        }
    }
}