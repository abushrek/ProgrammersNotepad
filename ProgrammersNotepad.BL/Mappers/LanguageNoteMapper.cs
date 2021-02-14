using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Mappers
{
    public class LanguageNoteMapper:IMapper<LanguageNoteDetailModel, LanguageNoteEntity>, IMapper<LanguageNoteListModel,LanguageNoteEntity>
    {
        private IMapper<LanguageListModel, LanguageEntity> _languageListMapper;
        private IMapper<LanguageDetailModel, LanguageEntity> _languageDetailMapper;
        public LanguageNoteMapper()
        {
            _languageListMapper = new LanguageMapper();
            _languageDetailMapper =new LanguageMapper();
        }

        LanguageNoteDetailModel IMapper<LanguageNoteDetailModel, LanguageNoteEntity>.MapEntityToModel(LanguageNoteEntity entity)
        {
            return new LanguageNoteDetailModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                Language = _languageDetailMapper.MapEntityToModel(entity.Language)
            };
        }

        public LanguageNoteEntity MapModelToEntity(LanguageNoteListModel model)
        {
            return new LanguageNoteEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Language = _languageListMapper.MapModelToEntity(model.Language)
            };
        }

        public LanguageNoteEntity MapModelToEntity(LanguageNoteDetailModel model)
        {
            return new LanguageNoteEntity()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Language = _languageDetailMapper.MapModelToEntity(model.Language)
            };
        }

        LanguageNoteListModel IMapper<LanguageNoteListModel, LanguageNoteEntity>.MapEntityToModel(LanguageNoteEntity entity)
        {
            return new LanguageNoteListModel()
            {
                Id = entity.Id,
                Title = entity.Title,
                Language = _languageListMapper.MapEntityToModel(entity.Language)
            };
        }
    }
}