using ProgrammersNotepad.BL.Facades.Interfaces;
using ProgrammersNotepad.BL.Services.Interfaces;
using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.ViewModels.BaseClasses;

namespace ProgrammersNotepad.ViewModels.DetailViewModels
{
    public class ImageDetailViewModel:BaseDetailViewModel<ImageDetailModel>
    {
        public ImageDetailViewModel(IDetailFacade<ImageDetailModel> facade, IMediator mediator) : base(facade, mediator)
        {

        }
    }
}