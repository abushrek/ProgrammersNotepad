using ProgrammersNotepad.Entities.Interfaces;

namespace ProgrammersNotepad.Entities
{
    public class LanguageEntity:BaseEntity,ILanguageEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}