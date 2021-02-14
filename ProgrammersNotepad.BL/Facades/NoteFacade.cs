using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades
{
    public class NoteFacade:BaseListDetailFacade<NoteListModel,NoteDetailModel,NoteEntity>
    {
        public NoteFacade(IRepository<NoteEntity> repository, IMapper<NoteDetailModel, NoteEntity> detailMapper, IMapper<NoteListModel, NoteEntity> listMapper) 
            : base(repository, detailMapper, listMapper)
        {
        }
    }
}