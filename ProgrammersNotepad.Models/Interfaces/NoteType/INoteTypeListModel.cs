using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.Models.Interfaces.NoteType
{
    public interface INoteTypeListModel:INoteTypeModel,IListModel
    {
        UserListModel User { get; set; }
    }
}