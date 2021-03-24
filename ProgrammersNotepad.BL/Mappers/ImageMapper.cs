using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.Models.Detail;

namespace ProgrammersNotepad.BL.Mappers
{
    public class ImageMapper:IMapper<ImageDetailModel,ImageEntity>
    {
        public ImageDetailModel MapEntityToModel(ImageEntity entity)
        {
            return new ImageDetailModel
            {
                Id =  entity.Id,
                Name =  entity.Name,
                Content = entity.Content
            };
        }

        public ImageEntity MapModelToEntity(ImageDetailModel model)
        {
            return new ImageEntity
            {
                Id = model.Id,
                Name = model.Name,
                Content = model.Content
            };
        }
    }
}