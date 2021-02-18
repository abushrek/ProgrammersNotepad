using System.Linq;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Mappers
{
    public class UserMapper:IMapper<UserDetailModel,UserEntity>, IMapper<UserListModel,UserEntity>
    {
        private IMapper<NoteDetailModel, NoteEntity> _noteDetailMapper;

        public UserMapper()
        {
            _noteDetailMapper = new NoteMapper();
        }

        UserDetailModel IMapper<UserDetailModel, UserEntity>.MapEntityToModel(UserEntity entity)
        {
            return new UserDetailModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email,
                ListOfNotes = entity.ListOfNotes?.Select(s => _noteDetailMapper.MapEntityToModel(s)).ToList(),
                Password = entity.Password
            };
        }

        public UserEntity MapModelToEntity(UserListModel model)
        {
            return new UserEntity()
            {
                Id = model.Id,
                Email = model.Email,
                Username = model.Username
            };
        }

        public UserEntity MapModelToEntity(UserDetailModel model)
        {
            return new UserEntity()
            {
                Id = model.Id,
                Username = model.Username,
                Email = model.Email,
                ListOfNotes = model.ListOfNotes.Select(s => _noteDetailMapper.MapModelToEntity(s)).ToList(),
                Password = model.Password
            };
        }

        UserListModel IMapper<UserListModel, UserEntity>.MapEntityToModel(UserEntity entity)
        {
            return new UserListModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email
            };
        }
    }
}