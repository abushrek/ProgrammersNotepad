using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.Models.Interfaces.NoteType;

namespace ProgrammersNotepad.Models.List
{
    public class NoteTypeListModel:BaseModel,INoteTypeListModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public UserListModel User { get; set; }
    }
}