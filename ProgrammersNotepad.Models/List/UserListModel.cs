using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.Models.Interfaces.User;

namespace ProgrammersNotepad.Models.List
{
    public class UserListModel:BaseModel,IUserListModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}