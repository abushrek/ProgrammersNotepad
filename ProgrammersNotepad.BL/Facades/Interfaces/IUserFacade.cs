using System.Threading.Tasks;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface IUserFacade<TModel>:IFacade<TModel> where TModel:IUserModel
    {
        TModel GetByUserName(string username);
        Task<TModel> GetByUserNameAsync(string username);
        string GetPasswordByUserName(string username);
        Task<string> GetPasswordByUserNameAsync(string username);
        bool Exists(string username);
        Task<bool> ExistsAsync(string username);
    }
}