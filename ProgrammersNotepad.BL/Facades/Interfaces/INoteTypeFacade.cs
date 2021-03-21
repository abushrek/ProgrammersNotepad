using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface INoteTypeFacade:IFacade<NoteTypeListModel>
    {
        IList<NoteTypeListModel> GetAllNoteTypesByUserId(Guid id);
        Task<IList<NoteTypeListModel>> GetAllNoteTypesByUserIdAsync(Guid id);
        NoteTypeListModel Add(NoteTypeListModel model, Guid userId);
        Task<NoteTypeListModel> AddAsync(NoteTypeListModel model, Guid userId, CancellationToken token);
    }
}