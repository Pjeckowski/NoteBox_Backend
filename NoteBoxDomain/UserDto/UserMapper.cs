using Notebox.DBModels.UserDataModel;

namespace NoteBoxDomain.UserDto
{
    public class UserMapper : IUserMapper
    {
        public UserDto MapUserToDto(UserDbModel user)
        {
            return new UserDto()
            {
                ID = user.Id,
                Email = user.Email,
                Nick = user.Nick
            };
        }

        public UserDbModel MapDtoToUserModel(UserWithPasswordDto user)
        {
            return new UserDbModel()
            {
                Email = user.Email,
                Nick = user.Nick,
                Password = user.Password
            };
        }

    }
}
