using System;
using System.Security.Principal;

namespace ProgrammersNotepad.BL.Services
{
    public class UserIdentity:IIdentity
    {
        public UserIdentity(Guid id, string username)
        {
            Id = id;
            Username = username;
        }

        public Guid Id { get; }
        public string Name => Username;
        public string Username { get; }
        public string AuthenticationType => "TCA authentication";
        public bool IsAuthenticated => Id != Guid.Empty;
    }
}