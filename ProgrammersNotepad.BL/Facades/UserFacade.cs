using System;
using System.Threading.Tasks;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades
{
    public class UserFacade:BaseListDetailFacade<UserListModel, UserDetailModel, UserEntity>, IUserFacade<UserListModel>, IUserFacade<UserDetailModel>
    {
        public new IUserRepository<UserEntity> Repository { get; protected set; }
        public UserFacade(IUserRepository<UserEntity> repository, IMapper<UserDetailModel, UserEntity> mapper, IMapper<UserListModel, UserEntity> listMapper) 
            : base(repository, mapper, listMapper)
        {
            Repository = repository;
        }
        
        UserListModel IUserFacade<UserListModel>.GetByUserName(string username)
        {
            return ListMapper.MapEntityToModel(Repository.GetByUserName(username));
        }
        
        async Task<UserDetailModel> IUserFacade<UserDetailModel>.GetByUserNameAsync(string username)
        {
            return DetailMapper.MapEntityToModel(await Repository.GetByUserNameAsync(username));
        }

        public bool Exists(string username)
        {
            return Repository.Exists(username);
        }

        public Task<bool> ExistsAsync(string username)
        {
            return Repository.ExistsAsync(username);
        }

        UserDetailModel IUserFacade<UserDetailModel>.GetByUserName(string username)
        {
            return DetailMapper.MapEntityToModel(Repository.GetByUserName(username));
        }

        async Task<UserListModel> IUserFacade<UserListModel>.GetByUserNameAsync(string username)
        {
            return ListMapper.MapEntityToModel(await Repository.GetByUserNameAsync(username));
        }

        public string GetPasswordByUserName(string username)
        {
            return Repository.GetPasswordByUserName(username);
        }

        public Task<string> GetPasswordByUserNameAsync(string username)
        {
            return Repository.GetPasswordByUserNameAsync(username);
        }
    }
}