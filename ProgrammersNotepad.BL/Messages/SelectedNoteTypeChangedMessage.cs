using ProgrammersNotepad.BL.Messages.Interfaces;
using ProgrammersNotepad.Models.List;

namespace ProgrammersNotepad.BL.Messages
{
    public class SelectedNoteTypeChangedMessage:IMessage
    {
        public NoteTypeListModel Model { get; set; }
    }
}