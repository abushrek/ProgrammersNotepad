using System;
using System.Collections;
using System.Collections.Generic;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface INoteFacade:IFacade<NoteListModel>
    {
        IList<NoteListModel> GetAllNotesByNoteType(Guid id);
    }
}