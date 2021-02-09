using System.Collections.Generic;
using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public class UserEntity: BaseEntity,IUserEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<NoteEntity> ListOfNotes { get; set; }
    }
}