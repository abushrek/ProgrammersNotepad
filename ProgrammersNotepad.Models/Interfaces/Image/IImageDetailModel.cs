using ProgrammersNotepad.Models.Detail;

namespace ProgrammersNotepad.Models.Interfaces.Image
{
    public interface IImageDetailModel:IImageModel,IDetailModel
    {
        string Name { get; set; }
        NoteDetailModel Note { get; set; }
    }
}