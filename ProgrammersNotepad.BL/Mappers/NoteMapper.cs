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
        private IMapper<NoteTypeDetailModel, NoteTypeEntity> _noteTypeMapper;
        private IMapper<NoteTypeListModel, NoteTypeEntity> _noteTypeListMapper;
        public NoteMapper(IMapper<NoteTypeDetailModel, NoteTypeEntity> noteTypeMapper, IMapper<NoteTypeListModel, NoteTypeEntity> noteTypeListMapper)
        {
            _noteTypeMapper = noteTypeMapper;
            _noteTypeListMapper = noteTypeListMapper;
        }

        NoteDetailModel IMapper<NoteDetailModel, NoteEntity>.MapEntityToModel(NoteEntity entity)
        {
            return new NoteDetailModel()
            {
                Id = entity.Id,
                RawText = entity.RawText,
                FormattedText = entity.FormattedText,
                Title = entity.Title,
                NoteType = _noteTypeMapper.MapEntityToModel(entity.NoteType)
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
                NoteType = _noteTypeListMapper.MapModelToEntity(model.NoteType)
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
                NoteType = _noteTypeMapper.MapModelToEntity(model.NoteType)
            };
        }

        NoteListModel IMapper<NoteListModel, NoteEntity>.MapEntityToModel(NoteEntity entity)
        {
            return new NoteListModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                NoteType = _noteTypeListMapper.MapEntityToModel(entity.NoteType)
            };
        }
    }
}