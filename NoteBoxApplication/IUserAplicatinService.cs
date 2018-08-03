using System.Collections.Generic;
using System.Threading.Tasks;
using NoteBoxDomain.UserDto;

namespace NoteBoxApplication
{
    public interface IUserAplicatinService
    {
        UserDto GetUserById(int id);

        List<UserDto> GetUsers();

        Task<UserDto> AddUser(UserWithPasswordDto user);
    }
}
