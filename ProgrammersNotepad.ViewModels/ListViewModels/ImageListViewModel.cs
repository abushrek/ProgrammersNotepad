using System;
using System.Collections.ObjectModel;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Models.List;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.Annotations.ListViewModels
{
    public class ImageListViewModel:BaseListViewModel<ImageListModel>
    {
        protected new IImageFacade<ImageListModel> Facade;
        private Guid _selectedNote;

        public ImageListViewModel(IImageFacade<ImageListModel> facade, IMediator mediator) : base(facade, mediator)
        {
            mediator.Register<SelectedNoteChangedMessage>(SelectedNoteChanged);
        }

        private void SelectedNoteChanged(SelectedNoteChangedMessage obj)
        {
            _selectedNote = obj.SelectedNoteId;
            Load();
        }

        public override void Load()
        {
            Models = _selectedNote != Guid.Empty ? new ObservableCollection<ImageListModel>(Facade.GetAllImagesByNoteId(_selectedNote)) : new ObservableCollection<ImageListModel>();
            base.Load();
        }
    }
}