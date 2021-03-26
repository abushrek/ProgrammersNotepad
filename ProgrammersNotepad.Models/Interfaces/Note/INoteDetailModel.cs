using ProgrammersNotepad.Models.Detail;
using ProgrammersNotepad.Models.Interfaces.NoteType;

namespace ProgrammersNotepad.Models.Interfaces.Note
{
    public interface INoteDetailModel:INoteModel, IDetailModel
    {
        string RawText { get; set; }
        string FormattedText { get; set; }
        NoteTypeDetailModel NoteType { get; set; }
    }
}