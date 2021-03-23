using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Common.Commands;
using ProgrammersNotepad.Models.List;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.Annotations.ListViewModels
{
    public class NoteListViewModel: BaseListViewModel<NoteListModel>
    {
        private NoteListModel _selectedNote;
        private readonly INoteFacade _noteFacade;
        private NoteTypeListModel _selectedNoteType;

        public NoteTypeListModel SelectedNoteType
        {
            get => _selectedNoteType;
            private set
            {
                _selectedNoteType = value;
                OnPropertyChanged();
            }
        }

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

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        public NoteListViewModel(INoteFacade noteFacade, IMediator mediator) : base(noteFacade, mediator)
        {
            _noteFacade = noteFacade;
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            Mediator.Register<SelectedNoteTypeChangedMessage>(OnSelectedNoteTypeChanged);
            Mediator.Register<RemoveNoteMessage>(OnRemoveNote);
        }

        private void Remove()
        {
            if (SelectedNote != null)
            {
                //TODO Remove selected note from db
                Models.Remove(SelectedNote);
            }
        }

        private void OnRemoveNote(RemoveNoteMessage obj)
        {
            NoteListModel model = Models.FirstOrDefault(s => s.Id == obj.Id);
            Models.Remove(model);
        }

        private void Add()
        {
            NoteListModel model = new NoteListModel()
            {
                Id = Guid.NewGuid(),
                Title = "New " + Facade.GetAll().Count(s => s.Title.StartsWith("New "))
            };
            Models.Add(model);
            _noteFacade.Add(model, SelectedNoteType.Id);
        }

        private void OnSelectedNoteTypeChanged(SelectedNoteTypeChangedMessage obj)
        {
            if(obj.Model != null)
                SelectedNoteType = obj.Model;
            else
                SelectedNoteType = null;
            Load();
        }

        public override void Load()
        {
            if (SelectedNoteType != null)
                Models = new ObservableCollection<NoteListModel>(_noteFacade.GetAllNotesByNoteType(SelectedNoteType.Id));
            else
                Models = new ObservableCollection<NoteListModel>();
            base.Load();
        }
    }
}