using Notebox.DBModels.UserDataModel;

namespace NoteBox.Domain.UserDtos
{
    public interface IUserMapper
    {
        UserDto MapUserToDto(UserDbModel user);

        UserDbModel MapDtoToUserModel(UserWithPasswordDto user);

    }
}
