using System;
using System.Security;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Common.Commands;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.Interfaces.User;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.DetailViewModels
{
    public class LoginViewModel:BaseDetailViewModel<UserDetailModel>
    {
        private IAuthService _authService;

        public ICommand LoginCommand { get; }

        public ICommand RegisterCommand { get; }

        public LoginViewModel(IDetailFacade<UserDetailModel> facade, IAuthService authService, IMediator mediator) : base(facade, mediator)
        {
            _authService = authService;
            LoginCommand = new RelayCommand<PasswordBox>(Login);
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register()
        {
            Mediator.Send(new RegisterMessage());
        }

        public void Login(PasswordBox passwordBox)
        {
            string password = passwordBox.Password;
            try
            {
                UserDetailModel user = _authService.AuthenticateUser(Model.Username, password);
                AuthenticationPrincipal.TCAPrincipal principal = Thread.CurrentPrincipal as AuthenticationPrincipal.TCAPrincipal;
                if (principal == null)
                {
                    return;
                }
                principal.Identity = new UserIdentity(user.Id, user.Username);
                Mediator.Send(new LoginMessage());
                //clearnutí textboxu a passwordboxu
                Model = new UserDetailModel();
                passwordBox.Password = "";
            }
            catch (UnauthorizedAccessException)
            {
                Mediator.Send(new LogoutMessage());
            }
            catch (Exception)
            {
                Mediator.Send(new LogoutMessage());
            }
        }
    }
}