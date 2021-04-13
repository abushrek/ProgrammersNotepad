using System;
using System.Collections.Generic;
using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public class UserEntity: BaseEntity,IUserEntity, IEquatable<UserEntity>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public virtual ICollection<NoteTypeEntity> NoteTypeCollection { get; set; }

        public UserEntity()
        {
            NoteTypeCollection = new List<NoteTypeEntity>();    
        }

        public bool Equals(UserEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Username == other.Username && Password == other.Password && Email == other.Email;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((UserEntity) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Username, Password, Email);
        }
    }
}