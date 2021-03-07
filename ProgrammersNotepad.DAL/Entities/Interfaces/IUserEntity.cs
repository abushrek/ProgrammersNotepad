using System.Collections.Generic;

namespace ProgrammersNotepad.DAL.Entities.Interfaces
{
    public interface IUserEntity:IEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<NoteTypeEntity> ListOfNoteTypes { get; set; }
    }
}