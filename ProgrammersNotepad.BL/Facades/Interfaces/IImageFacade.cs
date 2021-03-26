using System;
using System.Collections.Generic;
using ProgrammersNotepad.Models.Interfaces.Image;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface IImageFacade<TModel>: IDetailFacade<TModel> where TModel:IImageModel
    {
        ICollection<TModel> GetAllImagesByNoteId(Guid noteId);
    }
}