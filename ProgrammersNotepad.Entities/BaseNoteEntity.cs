using ProgrammersNotepad.Entities.Interfaces;

namespace ProgrammersNotepad.Entities
{
    public class BaseNoteEntity : BaseEntity, INoteEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}