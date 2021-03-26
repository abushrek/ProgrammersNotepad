﻿using ProgrammersNotepad.Models.Interfaces;
using ProgrammersNotepad.Models.Interfaces.Image;
using ProgrammersNotepad.Models.Interfaces.User;

namespace ProgrammersNotepad.Models.List
{
    public class ImageListModel:BaseModel, IImageListModel
    {
        public byte[] Content { get; set; }
        public NoteListModel Note { get; set; }
    }
}