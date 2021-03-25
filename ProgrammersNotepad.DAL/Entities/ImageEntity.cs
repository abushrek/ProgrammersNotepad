using System;
using System.IO;
using System.Net.Mime;

namespace ProgrammersNotepad.DAL.Entities
{
    public class ImageEntity:BaseEntity, IEquatable<ImageEntity>
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public virtual NoteEntity Note { get; set; }

        public bool Equals(ImageEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Name == other.Name && Equals(Content, other.Content);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ImageEntity) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Name, Content);
        }
    }
}