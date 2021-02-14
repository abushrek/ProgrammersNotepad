using System;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models
{
    public abstract class BaseModel:IModel
    {
        public Guid Id { get; set; }
    }
}