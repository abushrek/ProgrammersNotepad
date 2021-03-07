using System.Threading;
using System.Windows;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.DetailViewModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        private bool _isUserAuthorized;
        private Visibility _loginViewVisibility;
        private Visibility _mainViewVisibility;

        public bool IsUserAuthorized
        {
            get => _isUserAuthorized;
            set
            {
                _isUserAuthorized = value;
                LoginViewVisibility = _isUserAuthorized ? Visibility.Hidden : Visibility.Visible;
                MainViewVisibility = _isUserAuthorized ? Visibility.Visible : Visibility.Hidden;
                OnPropertyChanged();
            }
        }

        public Visibility LoginViewVisibility
        {
            get => _loginViewVisibility;
            set
            {
                _loginViewVisibility = value;
                OnPropertyChanged();
            }
        }

        public Visibility MainViewVisibility
        {
            get => _mainViewVisibility;
            set
            {
                _mainViewVisibility = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(IMediator mediator) : base(mediator)
        {
            Mediator.Register<LoginMessage>(OnMessageLogin);
            Mediator.Register<LogoutMessage>(OnMessageLogout);
            Load();
        }

        private void OnMessageLogout(LogoutMessage obj)
        {
            Load();
        }

        private void OnMessageLogin(LoginMessage obj)
        {
            Load();
        }

        public sealed override void Load()
        {
            IsUserAuthorized = Thread.CurrentPrincipal?.Identity?.IsAuthenticated ?? false;
            base.Load();
        }
    }
}