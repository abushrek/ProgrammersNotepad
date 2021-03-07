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
    public class NoteTypeFacade:BaseListDetailFacade<NoteTypeListModel,NoteTypeDetailModel,NoteTypeEntity>,INoteTypeFacade
    {
        private IRepository<UserEntity> _userRepository;

        public NoteTypeFacade(IRepository<NoteTypeEntity> repository,IUserRepository<UserEntity> userRepository, IMapper<NoteTypeDetailModel, NoteTypeEntity> detailMapper, IMapper<NoteTypeListModel, NoteTypeEntity> listMapper) : base(repository, detailMapper, listMapper)
        {
            _userRepository = userRepository;
        }

        public IList<NoteTypeListModel> GetAllNoteTypesByUserId(Guid id)
        {
            UserEntity user = _userRepository.GetById(id);
            IEnumerable < NoteTypeEntity > notes = user?.ListOfNoteTypes;
            return notes?.Select(s=> ListMapper.MapEntityToModel(s)).ToList();
        }

        public async Task<IList<NoteTypeListModel>> GetAllNoteTypesByUserIdAsync(Guid id)
        {
            return (await _userRepository.GetByIdAsync(id))?.ListOfNoteTypes?.Select(ListMapper.MapEntityToModel).ToList();
        }

    }
}