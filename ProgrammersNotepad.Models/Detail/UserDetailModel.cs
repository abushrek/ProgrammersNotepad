using System.Collections.Generic;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.Detail
{
    public class UserDetailModel:BaseModel, IUserDetailModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<NoteTypeDetailModel> ListOfNoteTypes { get; set; }
    }
}