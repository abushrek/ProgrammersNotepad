using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public class NoteEntity : BaseEntity, INoteEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}