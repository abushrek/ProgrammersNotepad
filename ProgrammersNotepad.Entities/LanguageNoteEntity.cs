using ProgrammersNotepad.Entities.Interfaces;

namespace ProgrammersNotepad.Entities
{
    public class LanguageNoteEntity : BaseNoteEntity, ILanguageNoteEntity
    {
        public LanguageEntity Language { get; set; }
    }
}