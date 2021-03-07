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
        BaseDetailFacade<TDetailModel,TEntity>, IFacade<TListModel>
        where TEntity : IEntity where TDetailModel : IDetailModel where TListModel : IListModel
    {
        protected readonly IMapper<TDetailModel, TEntity> DetailMapper;
        protected readonly IMapper<TListModel, TEntity> ListMapper;

        protected BaseListDetailFacade(IRepository<TEntity> repository, IMapper<TDetailModel, TEntity> detailMapper, IMapper<TListModel, TEntity> listMapper) : base(repository,detailMapper)
        {
            DetailMapper = detailMapper;
            ListMapper = listMapper;
        }

        public new IList<TListModel> GetAll()
        {
            return Repository.GetAll().Select(ListMapper.MapEntityToModel).ToList();
        }

        public new async Task<IList<TListModel>> GetAllAsync(CancellationToken token = default)
        {
            return (await Repository.GetAllAsync(token)).Select(ListMapper.MapEntityToModel).ToList();
        }

        public new TListModel GetById(Guid id)
        {
            TEntity tmp = Repository.GetById(id);
            return tmp != null ? ListMapper.MapEntityToModel(tmp) : default;
        }

        public new async Task<TListModel> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            TEntity tmp = await Repository.GetByIdAsync(id, token);
            return tmp != null ? ListMapper.MapEntityToModel(tmp) : default;
        }
    }
}