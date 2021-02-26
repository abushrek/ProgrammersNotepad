using System;
using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public class LanguageEntity:BaseEntity,ILanguageEntity, IEquatable<LanguageEntity>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Equals(LanguageEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Name == other.Name && Description == other.Description;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LanguageEntity) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, Description);
        }
    }
}