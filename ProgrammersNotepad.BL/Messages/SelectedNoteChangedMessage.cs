using System;
using ProgrammersNotepad.BL.Messages.Interfaces;

namespace ProgrammersNotepad.BL.Messages
{
    public class SelectedNoteChangedMessage:IMessage
    {
        public Guid SelectedNoteId { get; set; }
    }
}