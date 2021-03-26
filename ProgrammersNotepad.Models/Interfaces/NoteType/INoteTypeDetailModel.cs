using ProgrammersNotepad.Models.Detail;

namespace ProgrammersNotepad.Models.Interfaces.NoteType
{
    public interface INoteTypeDetailModel:INoteTypeModel,IDetailModel
    {
        UserDetailModel User { get; set; }
    }
}