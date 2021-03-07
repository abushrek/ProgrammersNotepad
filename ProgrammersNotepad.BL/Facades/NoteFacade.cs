using System;
using System.Collections.Generic;
using System.Linq;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades
{
    public class NoteFacade:BaseListDetailFacade<NoteListModel,NoteDetailModel,NoteEntity>, INoteFacade
    {
        private IRepository<NoteTypeEntity> _noteTypeRepository;
        public NoteFacade(IRepository<NoteEntity> repository, IMapper<NoteDetailModel, NoteEntity> mapper, IMapper<NoteListModel, NoteEntity> listMapper, IRepository<NoteTypeEntity> noteTypeRepository) 
            : base(repository, mapper, listMapper)
        {
            _noteTypeRepository = noteTypeRepository;
        }

        public IList<NoteListModel> GetAllNotesByNoteType(Guid id)
        {
            NoteTypeEntity type = _noteTypeRepository.GetById(id);
            return type.ListOfEntities.Select(ListMapper.MapEntityToModel).ToList();
        }
    }
}