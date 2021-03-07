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

        public IList<TModel> GetAll()
        {
            return Repository.GetAll().Select(_mapper.MapEntityToModel).ToList();
        }

        public async Task<IList<TModel>> GetAllAsync(CancellationToken token = default)
        {
            return (await Repository.GetAllAsync(token)).Select(_mapper.MapEntityToModel).ToList();
        }

        public TModel GetById(Guid id)
        {
            TEntity tmp = Repository.GetById(id);
            return tmp != null ? _mapper.MapEntityToModel(tmp) : default;
        }

        public async Task<TModel> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            TEntity tmp = await Repository.GetByIdAsync(id, token);
            return tmp != null ? _mapper.MapEntityToModel(tmp) : default;
        }

        public bool ModelExists(Guid id)
        {
            return Repository.GetAll().Any(s => _mapper.MapEntityToModel(s).Id == id);
        }
    }
}