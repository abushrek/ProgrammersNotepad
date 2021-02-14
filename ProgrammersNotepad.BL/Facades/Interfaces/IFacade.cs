using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface IFacade<TModel> where TModel : IModel
    {
        TModel Add(TModel model);
        Task<TModel> AddAsync(TModel model, CancellationToken token = default);
        void Remove(Guid id);
        Task RemoveAsync(Guid id, CancellationToken token = default);
        void Update(TModel model);
        Task UpdateAsync(TModel model, CancellationToken token = default);
        IEnumerable<TModel> GetAll();
        Task<IEnumerable<TModel>> GetAllAsync(CancellationToken token = default);
        TModel GetById(Guid id);
        Task<TModel> GetByIdAsync(Guid id, CancellationToken token = default);
        bool ModelExists(Guid id);
    }
}