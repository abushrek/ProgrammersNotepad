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

        public IList<NoteListModel> GetAllNotesByNoteType(Guid typeId)
        {
            NoteTypeEntity type = _noteTypeRepository.GetById(typeId);
            return type.ListOfEntities.Select(ListMapper.MapEntityToModel).ToList();
        }

        public NoteListModel Add(NoteListModel model, Guid typeId)
        {
            if (model == null)
                throw new ArgumentNullException();
            NoteEntity noteTypeEntity = ListMapper.MapModelToEntity(model);
            if (Repository.Add(noteTypeEntity) == null)
                return default;
            NoteTypeEntity entity = _noteTypeRepository.GetById(typeId);
            entity.ListOfEntities.Add(noteTypeEntity);
            _noteTypeRepository.Update(entity);
            return model;
        }

        public bool Remove(NoteListModel note, Guid typeId)
        {
            if(note == null)
                throw new ArgumentNullException();
            NoteTypeEntity entity = _noteTypeRepository.GetById(typeId);
            NoteEntity noteEntity = entity.ListOfEntities.FirstOrDefault(s => s.Id == note.Id);
            if (noteEntity == null) 
                return false;
            if (!Repository.Remove(note.Id)) 
                return false;
            entity.ListOfEntities.Remove(noteEntity);
            _noteTypeRepository.Update(entity);
            return true;
        }

        public async Task<NoteListModel> AddAsync(NoteListModel model, Guid typeId, CancellationToken token)
        {
            if (model == null)
                throw new ArgumentNullException();
            NoteEntity noteTypeEntity = ListMapper.MapModelToEntity(model);
            if (await Repository.AddAsync(noteTypeEntity, token) == null)
                return default;
            NoteTypeEntity entity = await _noteTypeRepository.GetByIdAsync(typeId, token);
            entity.ListOfEntities.Add(noteTypeEntity);
            await _noteTypeRepository.UpdateAsync(entity, token);
            return model;
        }
    }
}