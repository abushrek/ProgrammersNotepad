using System;
using System.Collections.Generic;
using System.Linq;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.Interfaces.Note;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades
{
    public class NoteFacade<TNoteModel>:BaseDetailFacade<TNoteModel, NoteEntity>, INoteFacade<TNoteModel> where TNoteModel:INoteModel
    {
        public NoteFacade(IRepository<NoteEntity> repository, IMapper<TNoteModel, NoteEntity> mapper) : base(repository, mapper)
        {
        }

        public ICollection<TNoteModel> GetAllNotesByNoteType(Guid typeId)
        {
            return Repository.GetAll().Where(s => s.NoteType?.Id == typeId).Select(Mapper.MapEntityToModel).ToList();
        }
    }
}