using System;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Mappers
{
    public class NoteMapper:IMapper<NoteDetailModel,NoteEntity>, IMapper<NoteListModel,NoteEntity>
    {
        public NoteMapper()
        {
        }

        NoteDetailModel IMapper<NoteDetailModel, NoteEntity>.MapEntityToModel(NoteEntity entity)
        {
            return new NoteDetailModel()
            {
                Id = entity.Id,
                RawText = entity.RawText,
                FormattedText = entity.FormattedText,
                Title = entity.Title,
            };
        }

        public NoteEntity MapModelToEntity(NoteListModel model)
        {
            return new NoteEntity()
            {
                Id = model.Id,
                RawText = "",
                FormattedText = "",
                Title = model.Title
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