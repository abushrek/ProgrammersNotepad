namespace ProgrammersNotepad.Entities.Interfaces
{
    public interface INoteEntity : IEntity
    {
        string Title { get; set; }
        string Description { get; set; }
    }
}