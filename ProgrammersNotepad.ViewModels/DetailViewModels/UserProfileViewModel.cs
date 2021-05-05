using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Common.Commands;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.DetailViewModels
{
    public class UserProfileViewModel:BaseDetailViewModel<UserDetailModel>
    {
        private Guid _currentUserGuid;
        public ICommand RemoveUserCommand { get; }

        public UserProfileViewModel(IDetailFacade<UserDetailModel> facade, IMediator mediator) : base(facade, mediator)
        {
            RemoveUserCommand = new RelayCommand(RemoveUser);

            mediator.Register<LoginMessage>(Login);

            Load();
        }

        private void Login(LoginMessage obj)
        {
            if (Thread.CurrentPrincipal is AuthenticationPrincipal.TCAPrincipal principal)
                _currentUserGuid = principal.Identity.Id;
            Load();
        }

        private void RemoveUser()
        {
            if (MessageBox.Show("Are you sure want to remove this account?", "Remove", MessageBoxButton.YesNo) ==
                MessageBoxResult.Yes)
            {
                Facade.RemoveAsync(Model.Id);
                if (Thread.CurrentPrincipal is AuthenticationPrincipal.TCAPrincipal principal)
                    principal.Identity = null;
                Mediator.Send(new LogoutMessage());
            }
        }

        public sealed override void Load()
        {
            Model = Facade.GetById(_currentUserGuid);
            base.Load();
        }
    }
}