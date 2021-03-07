using System;
using ProgrammersNotepad.DAL.Entities;

namespace ProgrammersNotepad.BL.Exceptions
{
    [Serializable]
    public class UserExistsException:Exception
    {
        public UserExistsException()
        {
            
        }

        public UserExistsException(string name):base("User with username "+name+" has already exists")
        {
            
        }
    }
}