using System.Collections.Generic;
using System.Threading.Tasks;
using NoteBoxDomain.UserDto;
using NoteBoxPersistance.UserRepository;

namespace NoteBoxApplication
{
    public class UserApplicationService : IUserAplicatinService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapper _mapper;

        public UserApplicationService()
        {
            _userRepository = new UserRepository();
            _mapper = new UserMapper();
        }
        public IUserDto GetUserById(int id)
        {
            return _mapper.MapUserToDto(_userRepository.ReadUser((uint) id));
        }

        public List<IUserDto> GetUsers()
        {
            var usersList = _userRepository.ReadUsers();
            List<IUserDto> userDtos = new List<IUserDto>();

            foreach (var user in usersList)
            {
                userDtos.Add(_mapper.MapUserToDto(user));
            }

            return userDtos;
        }

        public Task<IUserDto> AddUser(IUserWithPasswordDto user)
        {
            var userDataModel = _userRepository.CreateUser(_mapper.MapDtoToUserModel(user));

            return Task.FromResult(_mapper.MapUserToDto(userDataModel));
        }
    }
}
