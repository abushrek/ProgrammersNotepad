using System;
using System.Security;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Input;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Services;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Common.Commands;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.DetailViewModels
{
    public class LoginViewModel:BaseDetailViewModel<UserDetailModel>
    {
        private IAuthService _authService;

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(IDetailFacade<UserDetailModel> facade, IAuthService authService) : base(facade)
        {
            _authService = authService;
            LoginCommand = new RelayCommand<PasswordBox>(Login);
        }

        public void Login(PasswordBox passwordBox)
        {
            string password = passwordBox.Password;
            try
            {
                UserEntity user = _authService.AuthenticateUser(Model.Username, password);
                AuthenticationPrincipal.TCAPrincipal principal = Thread.CurrentPrincipal as AuthenticationPrincipal.TCAPrincipal;
                if (principal == null)
                {
                    return;
                }
                principal.Identity = new UserIdentity(user.Id, user.Email);
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (Exception)
            {
            }
        }
    }
}