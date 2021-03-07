using System;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Messages;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.DetailViewModels
{
    public class NoteDetailViewModel:BaseDetailViewModel<NoteDetailModel>
    {
        private Guid _selectedNote;
        public NoteDetailViewModel(IDetailFacade<NoteDetailModel> facade, IMediator mediator) : base(facade, mediator)
        {
            Mediator.Register<SelectedNoteChangedMessage>(SelectedNoteChanged);
        }

        private void SelectedNoteChanged(SelectedNoteChangedMessage obj)
        {
            _selectedNote = obj.SelectedNoteId;
            Load();
        }

        public override void Load()
        {
            Model = Facade.GetById(_selectedNote); 
            base.Load();
        }
    }
}