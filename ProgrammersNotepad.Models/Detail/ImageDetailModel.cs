using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.Models.Interfaces.Image;
using ProgrammersNotepad.Models.Interfaces.Note;

namespace ProgrammersNotepad.Models.Detail
{
    public class ImageDetailModel : BaseModel, IImageDetailModel
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public NoteDetailModel Note { get; set; }
    }
}