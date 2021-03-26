using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.Models.Interfaces.Note
{
    public interface INoteListModel:INoteModel, IListModel
    {
        NoteTypeListModel NoteType { get; set; }
    }
}