using System;
using System.Collections.Generic;

namespace ProgrammersNotepad.DAL.Entities
{
    public class NoteTypeEntity:BaseEntity, IEquatable<NoteTypeEntity>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual ICollection<NoteEntity> NoteCollection { get; set; }
        public bool Equals(NoteTypeEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Name == other.Name && Description == other.Description && Equals(User, other.User);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NoteTypeEntity) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, Description, User);
        }
    }
}