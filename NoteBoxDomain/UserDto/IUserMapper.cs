using NoteBoxDomain.UserDataModel;

namespace NoteBoxDomain.UserDto
{
    public interface IUserMapper
    {
        IUserDto MapUserToDto(IUserDataModel user);

        IUserDataModel MapDtoToUserModel(IUserWithPasswordDto user);

    }
}
