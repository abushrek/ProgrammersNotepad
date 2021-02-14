using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.List
{
    public class NoteListModel:BaseModel, IListModel
    {
        public string Title { get; set; }
    }
}