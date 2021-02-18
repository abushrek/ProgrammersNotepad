using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Facades
{
    public class UserFacade:BaseListDetailFacade<UserListModel, UserDetailModel, UserEntity>
    {
        public UserFacade(IRepository<UserEntity> repository, IMapper<UserDetailModel, UserEntity> mapper, IMapper<UserListModel, UserEntity> listMapper) 
            : base(repository, mapper, listMapper)
        {
        }
    }
}