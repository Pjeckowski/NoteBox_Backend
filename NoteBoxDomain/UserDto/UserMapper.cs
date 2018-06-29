using NoteBoxDomain.UserDataModel;

namespace NoteBoxDomain.UserDto
{
    public class UserMapper : IUserMapper
    {
        public IUserDto MapUserToDto(IUserDataModel user)
        {
            return new UserDto()
            {
                ID = user.ID,
                Email = user.Email,
                Nick = user.Nick
            };
        }

        public IUserDataModel MapDtoToUserModel(IUserWithPasswordDto user)
        {
            return new UserDataModel.UserDataModel()
            {
                Email = user.Email,
                Nick = user.Nick,
                Password = user.Password
            };
        }

    }
}
