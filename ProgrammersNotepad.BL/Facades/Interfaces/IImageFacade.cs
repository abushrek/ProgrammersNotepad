using System;
using System.Collections.Generic;
using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface IImageFacade<TModel>:IFacade<TModel> where TModel : IModel
    {
        ICollection<TModel> GetAllImagesByNoteId(Guid noteId);
    }
}