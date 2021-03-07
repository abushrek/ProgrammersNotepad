using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.Detail
{
    public class NoteDetailModel : BaseModel, IDetailModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public NoteTypeDetailModel Type { get; set; }
    }
}