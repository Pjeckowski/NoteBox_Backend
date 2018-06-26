using NoteBoxDomain.UserDto;

namespace NoteBoxApplication
{
    public interface IGetUserHandler
    {
        IUserDto Handle(int id);
    }
}
