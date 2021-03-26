using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProgrammersNotepad.Models.Interfaces.Note;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface INoteFacade<TModel>:IDetailFacade<TModel> where TModel: INoteModel
    {
        ICollection<TModel> GetAllNotesByNoteType(Guid typeId);
    }
}