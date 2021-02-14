using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.Detail
{
    public class LanguageDetailModel : BaseModel, IDetailModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}