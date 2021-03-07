using System.Collections.Generic;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.Detail
{
    public class NoteTypeDetailModel:BaseModel,IDetailModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<NoteDetailModel> ListOfNotes { get; set; }
    }
}