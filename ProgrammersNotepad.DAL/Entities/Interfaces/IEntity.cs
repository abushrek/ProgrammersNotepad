using System;

namespace ProgrammersNotepad.DAL.Entities.Interfaces
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}