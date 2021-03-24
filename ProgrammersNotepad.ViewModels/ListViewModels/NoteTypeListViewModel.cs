using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Common.Commands;
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

        public ICommand AddCommand { get; }

        public ICommand RemoveCommand { get; }

        public ICommand RemoveAllCommand { get; }

        public NoteTypeListViewModel(INoteTypeFacade facade, IMediator mediator) : base(facade, mediator)
        {
            Facade = facade;
            Mediator.Register<LoginMessage>(Login);
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand<NoteTypeListModel>(Remove);
            RemoveAllCommand = new RelayCommand(RemoveAll);
            Load();
        }

        private void RemoveAll()
        {
            if (Models != null)
            {
                if (MessageBox.Show("Do you really want to remove types?", "Remove types",
                    MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (_currentUserId != Guid.Empty)
                        Facade.ClearAllByUserId(_currentUserId);
                    Models.Clear();
                }
            }
        }

        private void Remove(NoteTypeListModel model)
        {
            if (model != null)
            {
                if(Facade.Remove(model, _currentUserId))
                    Models.Remove(model);
            }
        }

        private void Add()
        {
            NoteTypeListModel model = new NoteTypeListModel()
            {
                Id = Guid.NewGuid(),
                Name = "New",
                Description = "",
            };
            Facade.Add(model,_currentUserId);
            Models.Add(model);
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