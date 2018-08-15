using System.Collections.Generic;
using System.Threading.Tasks;
using Notebox.Data.Contract.MajorData;
using NoteBox.Application.Contract;
using NoteBox.Domain.MajorDtos;

namespace NoteBox.Application
{
    public class MajorApplicationService : IMajorApplicationService
    {
        private readonly IMajorRepository _majorRepository;
        private readonly IMajorMapper _majorMapper;

        public MajorApplicationService(IMajorRepository majorRepository, IMajorMapper majorMapper)
        {
            _majorRepository = majorRepository;
            _majorMapper = majorMapper;
        }

        public async Task<MajorDto> GetMajorByIdAsync(int id)
        {
            return _majorMapper.DbModelToDto(await _majorRepository.ReadMajorAsync(id));
        }

        public async Task<List<MajorDto>> GetMajorsAsync()
        {
            var majorsDb = await _majorRepository.ReadMajorsAsync();
            var majorsDto = new List<MajorDto>();

            foreach (var majorDb in majorsDb)
            {
                majorsDto.Add(_majorMapper.DbModelToDto(majorDb));
            }

            return majorsDto;
        }

        public async Task<List<MajorDto>> GetUserMajors(int userId)
        {
            var majorsDb = await _majorRepository.ReadMajorsByUserIdAsync(userId);
            var majorsDto = new List<MajorDto>();

            foreach (var majorDb in majorsDb)
            {
                majorsDto.Add(_majorMapper.DbModelToDto(majorDb));
            }

            return majorsDto;
        }

        public async Task<MajorDto> AddMajorAsync(MajorDto major)
        {
            var majorDb = await _majorRepository.CreateMajorAsync(_majorMapper.DtoToDbModel(major));

            return _majorMapper.DbModelToDto(majorDb);
        }
    }
}
