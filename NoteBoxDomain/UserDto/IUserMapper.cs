
using Notebox.DBModels.UserDataModel;

namespace NoteBoxDomain.UserDto
{
    public interface IUserMapper
    {
        UserDto MapUserToDto(UserDbModel user);

        UserDbModel MapDtoToUserModel(UserWithPasswordDto user);

    }
}
