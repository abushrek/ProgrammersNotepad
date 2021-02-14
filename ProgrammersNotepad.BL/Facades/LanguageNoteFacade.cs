using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades
{
    public class LanguageNoteFacade:BaseListDetailFacade<LanguageNoteListModel,LanguageNoteDetailModel,LanguageNoteEntity>
    {
        public LanguageNoteFacade(IRepository<LanguageNoteEntity> repository, IMapper<LanguageNoteDetailModel, LanguageNoteEntity> detailMapper, IMapper<LanguageNoteListModel, LanguageNoteEntity> listMapper) 
            : base(repository, detailMapper, listMapper)
        {
        }
    }
}