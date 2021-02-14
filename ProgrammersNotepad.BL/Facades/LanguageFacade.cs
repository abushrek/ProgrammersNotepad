using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades
{
    public class LanguageFacade:BaseListDetailFacade<LanguageListModel,LanguageDetailModel,LanguageEntity>
    {
        public LanguageFacade(IRepository<LanguageEntity> repository, IMapper<LanguageDetailModel, LanguageEntity> detailMapper, IMapper<LanguageListModel, LanguageEntity> listMapper) 
            : base(repository, detailMapper, listMapper)
        {
        }
    }
}