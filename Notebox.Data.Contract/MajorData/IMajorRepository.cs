using System.Collections.Generic;
using System.Threading.Tasks;
using Notebox.DBModels.MajorDataModel;

namespace Notebox.Data.Contract.MajorData
{
    public interface IMajorRepository
    {
        Task<MajorDbModel> CreateMajorAsync(MajorDbModel major);
        Task<List<MajorDbModel>> ReadMajorsAsync();
        Task<List<MajorDbModel>> ReadMajorsByUserIdAsync(int userId);
        Task<MajorDbModel> ReadMajorAsync(int id);
        Task UpdateMajorAsync(MajorDbModel major);
        Task DeleteMajorAsync(int id);
    }
}
