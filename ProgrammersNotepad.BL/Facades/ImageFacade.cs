using System;
using System.Collections.Generic;
using System.Linq;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades
{
    public class ImageFacade:BaseListDetailFacade<ImageListModel,ImageDetailModel,ImageEntity>, IImageFacade<ImageDetailModel>, IImageFacade<ImageListModel>
    {
        private new IImageRepository<ImageEntity> Repository;
        public ImageFacade(IImageRepository<ImageEntity> repository, IMapper<ImageDetailModel, ImageEntity> mapper, IMapper<ImageListModel,ImageEntity> listMapper) : base(repository, mapper, listMapper)
        {
            Repository = repository;
        }

        ICollection<ImageDetailModel> IImageFacade<ImageDetailModel>.GetAllImagesByNoteId(Guid noteId)
        {
            return Repository.GetAllByNoteId(noteId).Select(Mapper.MapEntityToModel).ToList();
        }

        ICollection<ImageListModel> IImageFacade<ImageListModel>.GetAllImagesByNoteId(Guid noteId)
        {
            return Repository.GetAllByNoteId(noteId).Select(ListMapper.MapEntityToModel).ToList();
        }
    }
}