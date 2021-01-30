namespace ProgrammersNotepad.Entities.Interfaces
{
    public interface ILanguageNoteEntity:INoteEntity
    {
        ILanguageEntity Language { get; set; }
    }
}