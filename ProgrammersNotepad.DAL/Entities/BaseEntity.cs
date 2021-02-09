using System;
using ProgrammersNotepad.DAL.Entities.Interfaces;

namespace ProgrammersNotepad.DAL.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}