using System.Collections.Generic;
using System.Threading.Tasks;
using NoteBox.Domain.SemesterDtos;

namespace NoteBox.Application.Contract
{
    public interface ISemesterApplicationService
    {
        Task<SemesterDto> GetSemesterByIdAsync(int id);

        Task<List<SemesterDto>> GetSemestersByMajorAsync();
    
        Task<SemesterDto> AddSemesterAsync(SemesterDto major);
    }
}
