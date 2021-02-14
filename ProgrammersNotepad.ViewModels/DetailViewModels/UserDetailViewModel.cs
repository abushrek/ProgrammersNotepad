using System;
using System.Windows.Input;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.Common.Commands;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.DetailViewModels
{
    public class UserDetailViewModel:BaseViewModel<UserDetailModel>
    {
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public UserDetailViewModel(IFacade<UserDetailModel> facade) : base(facade)
        {
            SaveCommand = new RelayCommand(Save);
            DeleteCommand = new RelayCommand(Delete);
        }

        public void Save()
        {
            UserDetailModel tmpModel = Facade.GetById(Model.Id);

            if (tmpModel == null)
            {
                Facade.Add(Model);
            }
            else
            {
                Facade.Update(Model);
            }
            Model = null;
        }

        public void Delete()
        {
            if (Model != null && Model.Id != Guid.Empty)
            {
                Facade.Remove(Model.Id);
            }
            Model = null;
        }
    }
}