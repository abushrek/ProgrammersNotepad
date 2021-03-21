using System;
using ProgrammersNotepad.BL.Messages.Interfaces;

namespace ProgrammersNotepad.BL.Messages
{
    public class RemoveNoteMessage:IMessage
    {
        public Guid Id { get; set; }

        public RemoveNoteMessage()
        {
            
        }
    }
}