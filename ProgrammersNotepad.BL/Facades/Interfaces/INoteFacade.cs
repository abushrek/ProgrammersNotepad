using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface INoteFacade:IFacade<NoteListModel>
    {
        IList<NoteListModel> GetAllNotesByNoteType(Guid typeId);
        NoteListModel Add(NoteListModel model, Guid typeId);
        bool Remove(NoteListModel note, Guid typeId);
        Task<NoteListModel> AddAsync(NoteListModel model, Guid typeId,CancellationToken token);
    }
}