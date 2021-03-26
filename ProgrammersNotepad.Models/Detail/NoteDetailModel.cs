using System.Collections.Generic;
using ProgrammersNotepad.Models.Interfaces.Note;
using ProgrammersNotepad.Models.Interfaces.NoteType;

namespace ProgrammersNotepad.Models.Detail
{
    public class NoteDetailModel : BaseModel, INoteDetailModel
    {
        public string Title { get; set; }
        public string RawText { get; set; }
        public string FormattedText { get; set; }
        public NoteTypeDetailModel NoteType { get; set; }
    }
}