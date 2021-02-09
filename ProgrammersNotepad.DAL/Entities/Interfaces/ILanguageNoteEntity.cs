namespace ProgrammersNotepad.DAL.Entities.Interfaces
{
    public interface ILanguageNoteEntity:INoteEntity
    {
        LanguageEntity Language { get; set; }
    }
}