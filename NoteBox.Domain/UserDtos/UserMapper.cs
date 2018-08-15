using Notebox.DBModels.UserDataModel;

namespace NoteBox.Domain.UserDtos
{
    public class UserMapper : IUserMapper
    {
        public UserDto MapUserToDto(UserDbModel user)
        {
            return new UserDto()
            {
                Id = user.Id,
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
