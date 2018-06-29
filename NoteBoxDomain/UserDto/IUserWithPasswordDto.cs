using System;
using System.Collections.Generic;
using System.Text;

namespace NoteBoxDomain.UserDto
{
    public interface IUserWithPasswordDto
    {
        string Password { get; }
        string Nick { get; }
        string Email { get; }
    }
}
