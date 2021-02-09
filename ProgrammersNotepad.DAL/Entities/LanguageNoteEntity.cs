using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public class LanguageNoteEntity : NoteEntity, ILanguageNoteEntity
    {
        public LanguageEntity Language { get; set; }
    }
}