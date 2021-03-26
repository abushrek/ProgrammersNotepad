using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProgrammersNotepad.Models.Interfaces.NoteType;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface INoteTypeFacade<TModel>: IDetailFacade<TModel> where TModel:INoteTypeModel
    {
        IList<TModel> GetAllNoteTypesByUserId(Guid id);
        Task<IList<TModel>> GetAllNoteTypesByUserIdAsync(Guid id);
        void ClearAllByUserId(Guid userId);
    }
}