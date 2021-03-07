
namespace ProgrammersNotepad.Models.Interfaces
{
    public interface IUserModel:IModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}