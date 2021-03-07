using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;

namespace ProgrammersNotepad.BL.Services.Interfaces
{
    public interface IAuthService:IService
    {
        UserDetailModel AuthenticateUser(string username, string password);
        UserDetailModel CreateUser(UserDetailModel user);
    }
}