using System.Security.Principal;

namespace ProgrammersNotepad.BL.Services
{
    public class AuthenticationPrincipal
    {
        public class TCAPrincipal : IPrincipal
        {
            public UserIdentity Identity { get; set; }

            IIdentity IPrincipal.Identity => Identity;

            public bool IsInRole(string role)
            {
                return true;
            }
        }
    }
}