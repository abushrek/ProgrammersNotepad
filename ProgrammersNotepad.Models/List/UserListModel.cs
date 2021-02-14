using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.List
{
    public class UserListModel:BaseModel,IListModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}