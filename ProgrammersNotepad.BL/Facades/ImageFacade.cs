using System;
using System.Collections.Generic;
using System.Linq;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.Interfaces.Image;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades
{
    public class ImageFacade<TIImageModel>:BaseDetailFacade<TIImageModel, ImageEntity>, IImageFacade<TIImageModel> where TIImageModel:IImageModel
    {
        private new IImageRepository<ImageEntity> Repository;
        public ImageFacade(IImageRepository<ImageEntity> repository, IMapper<TIImageModel, ImageEntity> mapper) : base(repository, mapper)
        {
            Repository = repository;
        }

        ICollection<TIImageModel> IImageFacade<TIImageModel>.GetAllImagesByNoteId(Guid noteId)
        {
            return Repository.GetAllByNoteId(noteId).Select(Mapper.MapEntityToModel).ToList();
        }
    }
}