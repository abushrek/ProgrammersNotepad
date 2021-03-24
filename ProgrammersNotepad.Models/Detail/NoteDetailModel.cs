using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.Detail
{
    public class NoteDetailModel : BaseModel, IDetailModel
    {
        public string Title { get; set; }
        public string RawText { get; set; }
        public string FormattedText { get; set; }
    }
}