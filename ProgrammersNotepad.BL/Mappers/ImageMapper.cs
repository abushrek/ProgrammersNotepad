using System;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Mappers
{
    public class ImageMapper: IMapper<ImageDetailModel,ImageEntity>, IMapper<ImageListModel, ImageEntity>
    {
        private IMapper<NoteDetailModel, NoteEntity> _noteMappper;
        private IMapper<NoteListModel, NoteEntity> _noteListMappper;
        public ImageMapper(IMapper<NoteDetailModel, NoteEntity> noteMappper, IMapper<NoteListModel, NoteEntity> noteListMappper)
        {
            _noteMappper = noteMappper;
            _noteListMappper = noteListMappper;
        }

        public ImageDetailModel MapEntityToModel(ImageEntity entity)
        {
            if (entity == null)
                return new ImageDetailModel();
            return new ImageDetailModel
            {
                Id =  entity.Id,
                Name =  entity.Name,
                Content = entity.Content,
                Note = _noteMappper.MapEntityToModel(entity.Note)
            };
        }

        public ImageEntity MapModelToEntity(ImageListModel model)
        {
            if (model == null)
                return new ImageEntity();
            return new ImageEntity()
            {
                Id =  model.Id,
                Name = "",
                Content = model.Content,
                Note = _noteListMappper.MapModelToEntity(model.Note)
            };
        }

        public ImageEntity MapModelToEntity(ImageDetailModel model)
        {
            if (model == null)
                return new ImageEntity();
            return new ImageEntity
            {
                Id = model.Id,
                Name = model.Name,
                Content = model.Content,
                Note = _noteMappper.MapModelToEntity(model.Note)
            };
        }

        ImageListModel IMapper<ImageListModel, ImageEntity>.MapEntityToModel(ImageEntity entity)
        {
            if (entity == null)
                return new ImageListModel();
            return new ImageListModel()
            {
                Id = entity.Id,
                Content = entity.Content,
                Note = _noteListMappper.MapEntityToModel(entity.Note)
            };
        }
    }
}