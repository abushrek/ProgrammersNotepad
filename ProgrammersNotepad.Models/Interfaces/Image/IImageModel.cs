namespace ProgrammersNotepad.Models.Interfaces.Image
{
    public interface IImageModel:IModel
    {
        public byte[] Content { get; set; }
    }
}