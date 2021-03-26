using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
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
        private readonly IDetailFacade<ImageDetailModel> _imageFadace;
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

        public ICommand AttachmentCommand { get; }

        public NoteDetailViewModel(IDetailFacade<NoteDetailModel> facade, IDetailFacade<ImageDetailModel> imageFadace, IMediator mediator) : base(facade, mediator)
        {
            _imageFadace = imageFadace;
            Mediator.Register<SelectedNoteChangedMessage>(SelectedNoteChanged);
            NoteVisibility = Visibility.Hidden;
            SaveCommand = new RelayCommand(Save);
            RemoveCommand = new RelayCommand(Remove);
            AttachmentCommand = new RelayCommand(Attach);
        }

        private void Attach()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            bool? show = dlg.ShowDialog();
            if (show != null && show == true)
            {
                string fileName;
                fileName = dlg.FileName;
                ImageDetailModel model = new ImageDetailModel()
                {
                    Id = Guid.NewGuid(),
                    Content = File.ReadAllBytes(fileName),
                    Name = "name",
                    Note = Model
                };
                _imageFadace.Add(model);
            }
        }

        private void Remove()
        {
            Facade.RemoveAsync(Model.Id);
            Mediator.Send(new RemoveNoteMessage()
            {
                Id= Model.Id
            });
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