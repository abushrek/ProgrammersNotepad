using System;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Mappers
{
    public class ImageMapper: Lazy<ImageMapper> ,IMapper<ImageDetailModel,ImageEntity>, IMapper<ImageListModel, ImageEntity>
    {
        private readonly IMapper<NoteDetailModel, NoteEntity> _noteMapper;

        public ImageMapper()
        {
            
        }

        public ImageMapper(IMapper<NoteDetailModel, NoteEntity> noteMapper)
        {
            _noteMapper = noteMapper;
        }

        public ImageDetailModel MapEntityToModel(ImageEntity entity)
        {
            return new ImageDetailModel
            {
                Id =  entity.Id,
                Name =  entity.Name,
                Content = entity.Content,
                Note = _noteMapper.MapEntityToModel(entity.Note)
            };
        }

        public ImageEntity MapModelToEntity(ImageListModel model)
        {
            return new ImageEntity()
            {
                Id =  model.Id,
                Name = "",
                Content = model.Content,
                Note = null
            };
        }

        public ImageEntity MapModelToEntity(ImageDetailModel model)
        {
            return new ImageEntity
            {
                Id = model.Id,
                Name = model.Name,
                Content = model.Content,
                Note = _noteMapper.MapModelToEntity(model.Note)
            };
        }

        ImageListModel IMapper<ImageListModel, ImageEntity>.MapEntityToModel(ImageEntity entity)
        {
            return new ImageListModel()
            {
                Id = entity.Id,
                Content = entity.Content,
            };
        }
    }
}