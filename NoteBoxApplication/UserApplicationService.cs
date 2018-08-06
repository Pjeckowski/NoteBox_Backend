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

        public UserApplicationService(IUserRepository userRepository, IUserMapper userMapper)
        {
            _userRepository = userRepository;
            _mapper = userMapper;
        }
        public UserDto GetUserById(int id)
        {
            return _mapper.MapUserToDto(_userRepository.ReadUser(id));
        }

        public List<UserDto> GetUsers()
        {
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
