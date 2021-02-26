using System;
using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public class LanguageNoteEntity : NoteEntity, ILanguageNoteEntity, IEquatable<LanguageNoteEntity>
    {
        public LanguageEntity Language { get; set; }

        public bool Equals(LanguageNoteEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Equals(Language, other.Language);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LanguageNoteEntity) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Language);
        }
    }
}