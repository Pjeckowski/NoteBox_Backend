using NoteBoxDomain.UserDataModel;

namespace NoteBoxDomain.UserDto
{
    public class UserToDtoMapper : IUserToDtoMapper
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
    }
}
