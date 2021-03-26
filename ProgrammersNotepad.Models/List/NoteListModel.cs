using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.Models.Interfaces.Note;

namespace ProgrammersNotepad.Models.List
{
    public class NoteListModel:BaseModel, INoteListModel
    {
        public string Title { get; set; }
        public NoteTypeListModel NoteType { get; set; }
    }
}