using System.Collections.Generic;
using System.Threading.Tasks;
using NoteBoxDomain.UserDto;

namespace NoteBoxApplication
{
    public interface IUserAplicatinService
    {
        IUserDto GetUserById(int id);

        List<IUserDto> GetUsers();

        Task<IUserDto> AddUser(IUserWithPasswordDto user);
    }
}
