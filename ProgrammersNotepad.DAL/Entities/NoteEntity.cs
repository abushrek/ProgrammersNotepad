﻿using System;
using System.Collections.Generic;
using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public class NoteEntity : BaseEntity, IEquatable<NoteEntity>
    {
        public string Title { get; set; }
        public string RawText { get; set; }
        public string FormattedText { get; set; }
        public virtual ICollection<ImageEntity> ImagesAsBytes{ get; set; }


        public bool Equals(NoteEntity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return base.Equals(other) && Title == other.Title && RawText == other.RawText && FormattedText == other.FormattedText && Equals(ImagesAsBytes, other.ImagesAsBytes);
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
            return HashCode.Combine(base.GetHashCode(), Title, RawText, FormattedText, ImagesAsBytes);
        }
    }
}