using System;
using System.Collections.Generic;
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
    }
}