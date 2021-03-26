
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.Models.Interfaces.Image
{
    public interface IImageListModel:IImageModel,IListModel
    {
        NoteListModel Note { get; set; }
    }
}