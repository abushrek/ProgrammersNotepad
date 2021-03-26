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
        protected IMapper<TModel, TEntity> Mapper;
        protected BaseDetailFacade(IRepository<TEntity> repository, IMapper<TModel, TEntity> mapper) : base(repository,mapper)
        {
            Mapper = mapper;
        }

        public virtual TModel Add(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException();
            if (Repository.Add(Mapper.MapModelToEntity(model)) == null)
                return default;
            return model;
        }

        public virtual async Task<TModel> AddAsync(TModel model, CancellationToken token = default)
        {
            if (model == null)
                throw new ArgumentNullException();
            if (await Repository.AddAsync(Mapper.MapModelToEntity(model), token) == null)
            {
                return default;
            }
            return model;
        }

        public virtual bool Remove(Guid id)
        {
            return Repository.Remove(id);
        }

        public virtual async Task RemoveAsync(Guid id, CancellationToken token = default)
        {
            await Repository.RemoveAsync(id, token);
        }

        public virtual void Update(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException();
            Repository.Update(Mapper.MapModelToEntity(model));
        }

        public virtual async Task UpdateAsync(TModel model, CancellationToken token = default)
        {
            if (model == null)
                throw new ArgumentNullException();
            await Repository.UpdateAsync(Mapper.MapModelToEntity(model), token);
        }
    }
}