using System.Threading.Tasks;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Repositories.Interfaces
{
    public interface IUserRepository<TEntity> :IRepository<TEntity> where TEntity : UserEntity
    {
        TEntity GetByUserName(string username);
        Task<TEntity> GetByUserNameAsync(string username);
        string GetPasswordByUserName(string username);
        Task<string> GetPasswordByUserNameAsync(string username);
        bool Exists(string username);
        Task<bool> ExistsAsync(string username);
    }
}