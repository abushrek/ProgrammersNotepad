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
    public abstract class BaseFacade<TModel, TEntity> : IFacade<TModel> where TModel:IModel where TEntity:IEntity
    {
        protected IRepository<TEntity> Repository;
        private readonly IMapper<TModel, TEntity> _mapper;

        protected BaseFacade(IRepository<TEntity> repository, IMapper<TModel, TEntity> mapper)
        {
            Repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TModel> GetAll()
        {
            return Repository.GetAll().Select(_mapper.MapEntityToModel);
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(CancellationToken token = default)
        {
            return (await Repository.GetAllAsync(token)).Select(_mapper.MapEntityToModel);
        }

        public TModel GetById(Guid id)
        {
            return _mapper.MapEntityToModel(Repository.GetById(id));
        }

        public async Task<TModel> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return _mapper.MapEntityToModel(await Repository.GetByIdAsync(id, token));
        }

        public bool ModelExists(Guid id)
        {
            return Repository.GetAll().Any(s => _mapper.MapEntityToModel(s).Id == id);
        }
    }
}