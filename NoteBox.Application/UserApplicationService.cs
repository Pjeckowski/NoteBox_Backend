using System.Collections.Generic;
using System.Threading.Tasks;
using Notebox.Data.Contract.UserData;
using NoteBox.Application.Contract;
using NoteBox.Domain.UserDtos;

namespace NoteBox.Application
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
        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            return _mapper.MapUserToDto(await _userRepository.ReadUserAsync(id));
        }

        public async Task<List<UserDto>> GetUsersAsync()
        {
            var usersList = await _userRepository.ReadUsersAsync();
            List<UserDto> userDtos = new List<UserDto>();

            foreach (var user in usersList)
            {
                userDtos.Add(_mapper.MapUserToDto(user));
            }

            return userDtos;
        }

        public async Task<UserDto> AddUserAsync(UserWithPasswordDto user)
        {
            var userDataModel = await _userRepository.CreateUserAsync(_mapper.MapDtoToUserModel(user));

            return _mapper.MapUserToDto(userDataModel);
        }
    }
}
