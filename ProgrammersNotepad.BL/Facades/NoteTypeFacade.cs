using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.Interfaces.Note;
using ProgrammersNotepad.Models.Interfaces.NoteType;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades
{
    public class NoteTypeFacade<TNoteTypeModel> : BaseDetailFacade<TNoteTypeModel, NoteTypeEntity>, INoteTypeFacade<TNoteTypeModel> where TNoteTypeModel: INoteTypeModel
    {
        protected new INoteTypeRepository<NoteTypeEntity> Repository;
        public NoteTypeFacade(INoteTypeRepository<NoteTypeEntity> repository, IMapper<TNoteTypeModel, NoteTypeEntity> mapper) : base(repository, mapper)
        {
            Repository = repository;
        }

        public IList<TNoteTypeModel> GetAllNoteTypesByUserId(Guid id)
        {
            return Repository.GetAllNoteTypesByUserId(id).Select(Mapper.MapEntityToModel).ToList();
        }

        public async Task<IList<TNoteTypeModel>> GetAllNoteTypesByUserIdAsync(Guid id, CancellationToken token = default)
        {

            return (await Repository.GetAllNoteTypesByUserIdAsync(id,token)).Select(Mapper.MapEntityToModel).ToList();
        }

        public void ClearAllByUserId(Guid userId)
        {
            Repository.ClearAllByUserId(userId);
        }
    }
}