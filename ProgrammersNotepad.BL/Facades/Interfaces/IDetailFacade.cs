using System;
using System.Threading;
using System.Threading.Tasks;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.BL.Facades.Interfaces
{
    public interface IDetailFacade<TModel>:IFacade<TModel> where TModel:IModel
    {
        TModel Add(TModel model);
        Task<TModel> AddAsync(TModel model, CancellationToken token = default);
        bool Remove(Guid id);
        Task RemoveAsync(Guid id, CancellationToken token = default);
        void Update(TModel model);
        Task UpdateAsync(TModel model, CancellationToken token = default);
    }
}