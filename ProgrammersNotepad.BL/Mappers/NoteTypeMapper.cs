using System.Linq;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Mappers
{
    public class NoteTypeMapper:IMapper<NoteTypeDetailModel,NoteTypeEntity>, IMapper<NoteTypeListModel,NoteTypeEntity>
    {
        private readonly IMapper<NoteDetailModel, NoteEntity> _noteMapper;

        public NoteTypeMapper()
        {
            _noteMapper = new NoteMapper();
        }

        NoteTypeDetailModel IMapper<NoteTypeDetailModel, NoteTypeEntity>.MapEntityToModel(NoteTypeEntity entity)
        {
            return new NoteTypeDetailModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description =  entity.Description,
                ListOfNotes = entity.ListOfEntities.Select(_noteMapper.MapEntityToModel).ToList()
            };
        }

        public NoteTypeEntity MapModelToEntity(NoteTypeListModel model)
        {
            return new NoteTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Description =  model.Description,
            };
        }

        public NoteTypeEntity MapModelToEntity(NoteTypeDetailModel model)
        {
            return new NoteTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ListOfEntities = model.ListOfNotes.Select(_noteMapper.MapModelToEntity).ToList()
            };
        }

        NoteTypeListModel IMapper<NoteTypeListModel, NoteTypeEntity>.MapEntityToModel(NoteTypeEntity entity)
        {
            return new NoteTypeListModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
            };
        }
    }
}