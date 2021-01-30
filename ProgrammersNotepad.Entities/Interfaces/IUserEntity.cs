using System.Collections.Generic;

namespace ProgrammersNotepad.Entities.Interfaces
{
    public interface IUserEntity:IEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<BaseNoteEntity> ListOfNotes { get; set; }
    }
}