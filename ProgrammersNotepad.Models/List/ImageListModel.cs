using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.List
{
    public class ImageListModel:BaseModel, IListModel
    {
        public byte[] Content { get; set; }
    }
}