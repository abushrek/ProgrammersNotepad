using ProgrammersNotepad.BL.Mappers.Interfaces;
using ProgrammersNotepad.DAL.Entities;
using ProgrammersNotepad.DAL.Repositories.Interfaces;
using ProgrammersNotepad.Models.Detail;

namespace ProgrammersNotepad.BL.Facades
{
    public class ImageFacade:BaseDetailFacade<ImageDetailModel,ImageEntity>
    {
        protected ImageFacade(IRepository<ImageEntity> repository, IMapper<ImageDetailModel, ImageEntity> mapper) : base(repository, mapper)
        {

        }
    }
}