﻿namespace NoteBoxDomain.UserDto
{
    public class UserWithPasswordDto : IUserWithPasswordDto
    {
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
