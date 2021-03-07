using System.Collections.Generic;
using ProgrammersNotepad.Models.Detail;

namespace ProgrammersNotepad.Models.Interfaces
{
    public interface IUserDetailModel:IUserModel,IDetailModel
    {
        string Password { get; set; }
        List<NoteTypeDetailModel> ListOfNoteTypes { get; set; }
    }
}