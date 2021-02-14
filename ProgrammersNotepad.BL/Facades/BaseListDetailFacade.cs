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
    public abstract class BaseListDetailFacade<TListModel,TDetailModel,TEntity>:
        BaseFacade<TDetailModel,TEntity>, IListDetailFacade<TListModel, TDetailModel>
        where TEntity : IEntity where TDetailModel : IDetailModel where TListModel : IListModel
    {
        private readonly IMapper<TDetailModel, TEntity> _detailMapper;
        private readonly IMapper<TListModel, TEntity> _listMapper;

        protected BaseListDetailFacade(IRepository<TEntity> repository, IMapper<TDetailModel, TEntity> detailMapper, IMapper<TListModel, TEntity> listMapper) : base(repository,detailMapper)
        {
            _detailMapper = detailMapper;
            _listMapper = listMapper;
        }

        public IEnumerable<TListModel> GetAllListModels()
        {
            return Repository.GetAll().Select(_listMapper.MapEntityToModel);
        }

        public async Task<IEnumerable<TListModel>> GetAllListModelsAsync(CancellationToken token = default)
        {
            return (await Repository.GetAllAsync(token)).Select(_listMapper.MapEntityToModel);
        }

        public TListModel GetListModelById(Guid id)
        {
            return _listMapper.MapEntityToModel(Repository.GetById(id));

        }

        public async Task<TListModel> GetListModelByIdAsync(Guid id, CancellationToken token = default)
        {
            return _listMapper.MapEntityToModel(await Repository.GetByIdAsync(id, token));
        }
    }
}