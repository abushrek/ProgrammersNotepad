using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public class LanguageEntity:BaseEntity,ILanguageEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}