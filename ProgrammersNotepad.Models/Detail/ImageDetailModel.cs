using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.Detail
{
    public class ImageDetailModel : BaseModel, IDetailModel
    {
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}