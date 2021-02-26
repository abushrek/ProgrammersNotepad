using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.BL.Services.Interfaces
{
    public interface IAuthService:IService
    {
        UserEntity AuthenticateUser(string email, string password);
        UserEntity CreateUser(UserEntity user);
    }
}