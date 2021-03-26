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
        protected new INoteFacade<NoteListModel> Facade;
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

        public NoteListViewModel(INoteFacade<NoteListModel> noteFacade, IMediator mediator) : base(noteFacade, mediator)
        {
            Facade = noteFacade;
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand<NoteListModel>(Remove);
            Mediator.Register<SelectedNoteTypeChangedMessage>(OnSelectedNoteTypeChanged);
            Mediator.Register<RemoveNoteMessage>(OnRemoveNote);
        }

        private void Remove(NoteListModel model)
        {
            if (model != null)
            {
                if(Facade.Remove(model.Id))
                    Models.Remove(model);
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
                Title = "New",
                NoteType = SelectedNoteType
            };
            Models.Add(model);
            Facade.Add(model);
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
                Models = new ObservableCollection<NoteListModel>(Facade.GetAllNotesByNoteType(SelectedNoteType.Id));
            else
                Models = new ObservableCollection<NoteListModel>();
            base.Load();
        }
    }
}