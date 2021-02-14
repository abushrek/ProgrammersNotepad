﻿using System.Windows.Input;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.Common.Commands;
using ProgrammersNotepad.Models.List;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.Annotations.ListViewModels
{
    public class UserListViewModel:BaseListViewModel<UserListModel>
    {
        public ICommand UserSelectedCommand;

        public UserListViewModel(IFacade<UserListModel> facade) : base(facade)
        {
            UserSelectedCommand = new RelayCommand(UserSelected);
        }

        private void UserSelected()
        {
            
        }
    }
}