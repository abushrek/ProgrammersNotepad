using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.List
{
    public class LanguageListModel : BaseModel, IListModel
    {
        public string Name { get; set; }
    }
}