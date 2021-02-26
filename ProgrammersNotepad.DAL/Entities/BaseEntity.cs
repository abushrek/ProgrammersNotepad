using System;
using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public abstract class BaseEntity : IEntity, IEquatable<BaseEntity>
    {
        public Guid Id { get; set; }

        public bool Equals(BaseEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((BaseEntity) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}