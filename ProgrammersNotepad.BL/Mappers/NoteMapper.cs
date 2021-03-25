using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Mappers
{
    public class NoteMapper:IMapper<NoteDetailModel,NoteEntity>, IMapper<NoteListModel,NoteEntity>
    {
        private readonly IMapper<ImageDetailModel, ImageEntity> _imageMapper;
        public NoteMapper(IMapper<ImageDetailModel, ImageEntity> imageMapper)
        {
            _imageMapper = imageMapper;
        }

        NoteDetailModel IMapper<NoteDetailModel, NoteEntity>.MapEntityToModel(NoteEntity entity)
        {
            return new NoteDetailModel()
            {
                Id = entity.Id,
                RawText = entity.RawText,
                FormattedText = entity.FormattedText,
                Title = entity.Title,
                ImagesAsBytes = new ObservableCollection<ImageDetailModel>(entity.ImagesAsBytes.Select(_imageMapper.MapEntityToModel))
            };
        }

        public NoteEntity MapModelToEntity(NoteListModel model)
        {
            return new NoteEntity()
            {
                Id = model.Id,
                RawText = "",
                FormattedText = "",
                Title = model.Title,
                ImagesAsBytes = new List<ImageEntity>()
            };
        }

        public NoteEntity MapModelToEntity(NoteDetailModel model)
        {
            return new NoteEntity()
            {
                Id = model.Id,
                RawText = model.RawText,
                FormattedText = model.FormattedText,
                Title = model.Title,
                ImagesAsBytes = model.ImagesAsBytes.Select(_imageMapper.MapModelToEntity).ToList()
            };
        }

        NoteListModel IMapper<NoteListModel, NoteEntity>.MapEntityToModel(NoteEntity entity)
        {
            return new NoteListModel()
            {
                Id = entity.Id,
                Title = entity.Title
            };
        }
    }
}