using System.Collections.Generic;
using System.Threading.Tasks;
using Notebox.Data;
using Notebox.Data.Contract;
using NoteBoxDomain.UserDto;

namespace NoteBoxApplication
{
    public class UserApplicationService : IUserAplicatinService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _mapper;

        public UserApplicationService()
        {
            _userRepository = new UserRepository(new ContextFactory());
            _mapper = new UserMapper();
        }
        public UserDto GetUserById(int id)
        {
            return _mapper.MapUserToDto(_userRepository.ReadUser(id));
        }

        public List<UserDto> GetUsers()
        {

            return new List<UserDto>{new UserDto
            {
                Email = "kupa"
            }};
            var usersList = _userRepository.ReadUsers();
            List<UserDto> userDtos = new List<UserDto>();

            foreach (var user in usersList)
            {
                userDtos.Add(_mapper.MapUserToDto(user));
            }

            return userDtos;
        }

        public Task<UserDto> AddUser(UserWithPasswordDto user)
        {
            var userDataModel = _userRepository.CreateUser(_mapper.MapDtoToUserModel(user));

            return Task.FromResult(_mapper.MapUserToDto(userDataModel));
        }
    }
}
