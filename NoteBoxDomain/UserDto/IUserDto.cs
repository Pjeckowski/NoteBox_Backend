using System;
using System.Collections.Generic;
using System.Text;

namespace NoteBoxDomain.UserDto
{
    public interface IUserDto
    {
        int ID { get; set; }
        string Nick { get; set; }
        string Email { get; set; }
    }
}
