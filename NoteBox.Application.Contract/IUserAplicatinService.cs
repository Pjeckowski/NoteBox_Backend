using System.Collections.Generic;
using System.Threading.Tasks;
using NoteBox.Domain.UserDtos;

namespace NoteBox.Application.Contract
{
    public interface IUserAplicatinService
    {
        Task<UserDto> GetUserByIdAsync(int id);

        Task<List<UserDto>> GetUsersAsync();

        Task<UserDto> AddUserAsync(UserWithPasswordDto user);
    }
}
