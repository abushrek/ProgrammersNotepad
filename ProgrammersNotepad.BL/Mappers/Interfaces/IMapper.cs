using ProgrammersNotepad.DAL.Entities.Interfaces;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.BL.Mappers.Interfaces
{
    public interface IMapper <TModel, TEntity> where TModel:IModel where TEntity:IEntity
    {
        TModel MapEntityToModel(TEntity entity);
        TEntity MapModelToEntity(TModel model);
    }
}