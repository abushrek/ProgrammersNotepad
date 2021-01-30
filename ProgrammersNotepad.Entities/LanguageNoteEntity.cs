using ProgrammersNotepad.Entities.Interfaces;

namespace ProgrammersNotepad.Entities
{
    public class LanguageNoteEntity : BaseNoteEntity, ILanguageNoteEntity
    {
        public ILanguageEntity Language { get; set; }
    }
}