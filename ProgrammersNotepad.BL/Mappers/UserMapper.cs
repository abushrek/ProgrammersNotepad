using System.Collections.Generic;
using System.Linq;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Mappers
{
    public class UserMapper:IMapper<UserDetailModel,UserEntity>, IMapper<UserListModel,UserEntity>
    {

        public UserMapper()
        {
        }

        UserDetailModel IMapper<UserDetailModel, UserEntity>.MapEntityToModel(UserEntity entity)
        {
            if (entity == null)
                return new UserDetailModel();
            return new UserDetailModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email,
                Password = entity.Password
            };
        }

        public UserEntity MapModelToEntity(UserListModel model)
        {
            if (model == null)
                return new UserEntity();
            return new UserEntity()
            {
                Id = model.Id,
                Email = model.Email,
                Username = model.Username,
                Password = ""
            };
        }

        public UserEntity MapModelToEntity(UserDetailModel model)
        {
            if (model == null)
                return new UserEntity();
            return new UserEntity()
            {
                Id = model.Id,
                Username = model.Username,
                Email = model.Email,
                Password = model.Password
            };
        }

        UserListModel IMapper<UserListModel, UserEntity>.MapEntityToModel(UserEntity entity)
        {
            if(entity == null)
                return new UserListModel();
            return new UserListModel()
            {
                Id = entity.Id,
                Username = entity.Username,
                Email = entity.Email
            };
        }
    }
}