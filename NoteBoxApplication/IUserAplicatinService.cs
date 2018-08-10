using System.Collections.Generic;
using System.Threading.Tasks;
using NoteBoxDomain.UserDto;

namespace NoteBoxApplication
{
    public interface IUserAplicatinService
    {
        Task<UserDto> GetUserByIdAsync(int id);

        Task<List<UserDto>> GetUsersAsync();

        Task<UserDto> AddUserAsync(UserWithPasswordDto user);
    }
}
