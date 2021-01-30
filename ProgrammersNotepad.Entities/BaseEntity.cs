using System;
using ProgrammersNotepad.Entities.Interfaces;

namespace ProgrammersNotepad.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}