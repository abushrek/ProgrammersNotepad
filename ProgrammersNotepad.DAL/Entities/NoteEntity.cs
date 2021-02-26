using System;
using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public class NoteEntity : BaseEntity, INoteEntity, IEquatable<NoteEntity>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public bool Equals(NoteEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Title == other.Title && Description == other.Description;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NoteEntity) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Title, Description);
        }
    }
}