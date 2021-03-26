using System.Collections.Generic;
using System.Linq;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Mappers
{
    public class NoteTypeMapper:IMapper<NoteTypeDetailModel,NoteTypeEntity>, IMapper<NoteTypeListModel,NoteTypeEntity>
    {
        private IMapper<UserDetailModel, UserEntity> _userMapper;
        private IMapper<UserListModel, UserEntity> _userListMapper;

        public NoteTypeMapper(IMapper<UserDetailModel, UserEntity> userMapper, IMapper<UserListModel, UserEntity> userListMapper)
        {
            _userMapper = userMapper;
            _userListMapper = userListMapper;
        }

        NoteTypeDetailModel IMapper<NoteTypeDetailModel, NoteTypeEntity>.MapEntityToModel(NoteTypeEntity entity)
        {
            return new NoteTypeDetailModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description =  entity.Description,
                User = _userMapper.MapEntityToModel(entity.User)
            };
        }

        public NoteTypeEntity MapModelToEntity(NoteTypeListModel model)
        {
            return new NoteTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Description =  model.Description,
                User = _userListMapper.MapModelToEntity(model.User)
            };
        }

        public NoteTypeEntity MapModelToEntity(NoteTypeDetailModel model)
        {
            return new NoteTypeEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                User = _userMapper.MapModelToEntity(model.User)
            };
        }

        NoteTypeListModel IMapper<NoteTypeListModel, NoteTypeEntity>.MapEntityToModel(NoteTypeEntity entity)
        {
            return new NoteTypeListModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                User = _userListMapper.MapEntityToModel(entity.User)
            };
        }
    }
}