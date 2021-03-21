using System;
using System.Windows;
using System.Windows.Input;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Common.Commands;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.DetailViewModels
{
    public class NoteDetailViewModel:BaseDetailViewModel<NoteDetailModel>
    {
        private Guid _selectedNote;
        private Visibility _noteVisibility;

        public Visibility NoteVisibility
        {
            get => _noteVisibility;
            set
            {
                _noteVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        public ICommand RemoveCommand { get; }

        public NoteDetailViewModel(IDetailFacade<NoteDetailModel> facade, IMediator mediator) : base(facade, mediator)
        {
            Mediator.Register<SelectedNoteChangedMessage>(SelectedNoteChanged);
            NoteVisibility = Visibility.Hidden;
            SaveCommand = new RelayCommand(Save);
            RemoveCommand = new RelayCommand(Remove);
        }

        private void Remove()
        {
            Facade.RemoveAsync(Model.Id);
            _selectedNote = Guid.Empty;
            Model = null;
            Load();
        }

        private void Save()
        {
            Facade.Update(Model);
        }

        private void SelectedNoteChanged(SelectedNoteChangedMessage obj)
        {
            _selectedNote = obj.SelectedNoteId;
            Load();
        }

        public override void Load()
        {
            Model = _selectedNote != Guid.Empty ? Facade.GetById(_selectedNote) : null;
            NoteVisibility = Model is not null ? Visibility.Visible : Visibility.Hidden;
            base.Load();
        }
    }
}