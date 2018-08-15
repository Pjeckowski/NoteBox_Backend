using System.Collections.Generic;
using System.Threading.Tasks;
using NoteBox.Domain.MajorDtos;

namespace NoteBox.Application.Contract
{
    public interface IMajorApplicationService
    {
        Task<MajorDto> GetMajorByIdAsync(int id);

        Task<List<MajorDto>> GetMajorsAsync();

        Task<List<MajorDto>> GetUserMajors(int userId);
        
        Task<MajorDto> AddMajorAsync(MajorDto major);
    }
}
