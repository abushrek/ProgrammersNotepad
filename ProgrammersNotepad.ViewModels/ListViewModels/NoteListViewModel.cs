﻿using System;
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

        public ICommand AddCommand { get; }

        public NoteListViewModel(INoteFacade noteFacade, IMediator mediator) : base(noteFacade, mediator)
        {
            _noteFacade = noteFacade;
            AddCommand = new RelayCommand(Add);
            Mediator.Register<SelectedNoteTypeChangedMessage>(OnSelectedNoteTypeChanged);
            Mediator.Register<RemoveNoteMessage>(OnRemoveNote);
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
            _noteFacade.Add(model, _selectedNoteType);
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