using NoteBoxDomain.UserDto;
using NoteBoxPersistance.UserRepository;

namespace NoteBoxApplication
{
    public class GetUserHandler : IGetUserHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserToDtoMapper _mapper;

        public GetUserHandler()
        {
            _userRepository = new UserRepository();
            _mapper = new UserToDtoMapper();
        }
        public IUserDto Handle(int id)
        {
            return _mapper.MapUserToDto(_userRepository.ReadUser((uint) id));
        }
    }
}
