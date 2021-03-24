using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
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

        public NoteTypeListViewModel(INoteTypeFacade facade, IMediator mediator) : base(facade, mediator)
        {
            Facade = facade;
            Mediator.Register<LoginMessage>(Login);
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            Load();
        }

        private void Remove()
        {
            if (SelectedType != null)
            {
                if(Facade.Remove(SelectedType, _currentUserId))
                    Models.Remove(SelectedType);
            }
        }

        private void Add()
        {
            NoteTypeListModel model = new NoteTypeListModel()
            {
                Id = Guid.NewGuid(),
                Name = "New "+Facade.GetAll().Count(s => s.Name.StartsWith("New ")),
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