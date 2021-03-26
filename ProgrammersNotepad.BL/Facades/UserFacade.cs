using System;
using System.Threading.Tasks;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Interfaces.User;

namespace ProgrammersNotepad.BL.Facades
{
    public class UserFacade<TUserModel>:BaseDetailFacade<TUserModel, UserEntity>, IUserFacade<TUserModel> where TUserModel:IUserModel
    {
        public new IUserRepository<UserEntity> Repository { get; protected set; }
        public UserFacade(IUserRepository<UserEntity> repository, IMapper<TUserModel, UserEntity> mapper) : base(repository, mapper)
        {
            Repository = repository;
        }

        public async Task<TUserModel> GetByUserNameAsync(string username)
        {
            return Mapper.MapEntityToModel(await Repository.GetByUserNameAsync(username));
        }

        public TUserModel GetByUserName(string username)
        {
            return Mapper.MapEntityToModel(Repository.GetByUserName(username));
        }

        public bool Exists(string username)
        {
            return Repository.Exists(username);
        }

        public Task<bool> ExistsAsync(string username)
        {
            return Repository.ExistsAsync(username);
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