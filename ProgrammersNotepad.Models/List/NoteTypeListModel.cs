using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.List
{
    public class NoteTypeListModel:BaseModel,IListModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}