using System.Collections.Generic;
using ProgrammersNotepad.Models.Interfaces.NoteType;
using ProgrammersNotepad.Models.Interfaces.User;

namespace ProgrammersNotepad.Models.Detail
{
    public class NoteTypeDetailModel : BaseModel, INoteTypeDetailModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public UserDetailModel User { get; set; }
    }
}