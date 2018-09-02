using System.Collections.Generic;
using System.Threading.Tasks;
using Notebox.DBModels.MajorDataModel;
using Notebox.DBModels.SemesterDataModel;

namespace Notebox.Data.Contract.SemesterData
{
    public interface ISemesterRepository
    {
        Task<SemesterDbModel> CreateSemesterAsync(SemesterDbModel semester);
        Task<List<SemesterDbModel>> ReadSemestersAsync(int? count=null, int? skip=null);
        Task<List<SemesterDbModel>> ReadSemestersByMajorIdAsync(int majorId);
        Task<SemesterDbModel> ReadSemesterAsync(int id);
        Task UpdateSemesterAsync(SemesterDbModel major);
        Task DeleteSemesterAsync(int id);
    }
}
