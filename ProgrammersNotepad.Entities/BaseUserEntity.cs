using System.Collections.Generic;
using ProgrammersNotepad.Entities.Interfaces;

namespace ProgrammersNotepad.Entities
{
    public class BaseUserEntity:BaseEntity, IUserEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<BaseNoteEntity> ListOfNotes { get; set; }
    }
}