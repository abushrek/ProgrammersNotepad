using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities.Interfaces;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.BL.Facades
{
    public class BaseDetailFacade<TModel, TEntity>:BaseFacade<TModel,TEntity>,IDetailFacade<TModel> where TModel : IModel where TEntity:IEntity
    {
        private readonly IMapper<TModel, TEntity> _mapper;
        protected BaseDetailFacade(IRepository<TEntity> repository, IMapper<TModel, TEntity> mapper) : base(repository,mapper)
        {
            _mapper = mapper;
        }

        public TModel Add(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException();
            if (Repository.Add(_mapper.MapModelToEntity(model)) == null)
                return default;
            return model;
        }

        public async Task<TModel> AddAsync(TModel model, CancellationToken token = default)
        {
            if (model == null)
                throw new ArgumentNullException();
            if (await Repository.AddAsync(_mapper.MapModelToEntity(model), token) == null)
            {
                return default;
            }
            return model;
        }

        public void Remove(Guid id)
        {
            Repository.Remove(id);
        }

        public async Task RemoveAsync(Guid id, CancellationToken token = default)
        {
            await Repository.RemoveAsync(id, token);
        }

        public void Update(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException();
            Repository.UpdateAsync(_mapper.MapModelToEntity(model));
        }

        public async Task UpdateAsync(TModel model, CancellationToken token = default)
        {
            if (model == null)
                throw new ArgumentNullException();
            await Repository.UpdateAsync(_mapper.MapModelToEntity(model), token);
        }
    }
}