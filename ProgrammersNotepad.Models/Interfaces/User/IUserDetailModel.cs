namespace ProgrammersNotepad.Models.Interfaces.User
{
    public interface IUserDetailModel:IUserModel,IDetailModel
    {
        string Password { get; set; }
    }
}