using NoteBoxDomain.UserDataModel;

namespace NoteBoxDomain.UserDto
{
    public interface IUserToDtoMapper
    {
        IUserDto MapUserToDto(IUserDataModel user);
    }
}
