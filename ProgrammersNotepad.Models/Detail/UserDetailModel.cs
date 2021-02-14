﻿using System.Collections.Generic;
using ProgrammersNotepad.Models.Interfaces;

namespace ProgrammersNotepad.Models.Detail
{
    public class UserDetailModel:BaseModel, IDetailModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<NoteDetailModel> ListOfNotes { get; set; }
    }
}