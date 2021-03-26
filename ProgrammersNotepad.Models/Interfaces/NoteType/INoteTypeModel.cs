using ProgrammersNotepad.Models.Detail;

namespace ProgrammersNotepad.Models.Interfaces.NoteType
{
    public interface INoteTypeModel:IModel
    {
        string Name { get; set; }
        string Description { get; set; }
    }
}