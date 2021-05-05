using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using ProgrammersNotepad.BL.Exceptions;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Common.Commands;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.DetailViewModels
{
    public class RegisterViewModel:BaseDetailViewModel<UserDetailModel>
    {
        private IAuthService _authService;
        public ICommand RegisterCommand { get; }
        public ICommand BackToLoginCommand { get; }
        public RegisterViewModel(IDetailFacade<UserDetailModel> facade, IAuthService authService, IMediator mediator) : base(facade, mediator)
        {
            _authService = authService;
            RegisterCommand = new RelayCommand<PasswordBox>(Register);
            BackToLoginCommand = new RelayCommand(BackToLogin);
        }

        private void BackToLogin()
        {
            Mediator.Send(new LogoutMessage());
        }

        private void Register(PasswordBox obj)
        {
            if (obj.Password.Length >= 6)
            {
                Model.Id = Guid.NewGuid();
                Model.Password = obj.Password;
                try
                {
                    if (_authService.CreateUser(Model) != null)
                    {
                        Login(obj.Password);
                    }
                }
                catch (UserExistsException e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        private void Login(string password)
        {
            _authService.AuthenticateUser(Model.Username, password);
            AuthenticationPrincipal.TCAPrincipal principal = Thread.CurrentPrincipal as AuthenticationPrincipal.TCAPrincipal;
            if (principal == null)
            {
                return;
            }
            principal.Identity = new UserIdentity(Model.Id, Model.Username);
            Mediator.Send(new LoginMessage());
        }
    }
}