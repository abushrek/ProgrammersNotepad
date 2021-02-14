using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Mappers
{
    public class LanguageMapper:IMapper<LanguageDetailModel,LanguageEntity>, IMapper<LanguageListModel,LanguageEntity>
    {
        LanguageDetailModel IMapper<LanguageDetailModel, LanguageEntity>.MapEntityToModel(LanguageEntity entity)
        {
            return new LanguageDetailModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
            };
        }

        public LanguageEntity MapModelToEntity(LanguageListModel model)
        {
            return new LanguageEntity()
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public LanguageEntity MapModelToEntity(LanguageDetailModel model)
        {
            return new LanguageEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
        }

        LanguageListModel IMapper<LanguageListModel, LanguageEntity>.MapEntityToModel(LanguageEntity entity)
        {
            return new LanguageListModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}