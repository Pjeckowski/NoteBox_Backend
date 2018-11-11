using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notebox.Data.Contract.MajorData;
using Notebox.Data.Contract.SemesterData;
using Notebox.DBModels.MajorDataModel;
using Notebox.DBModels.SemesterDataModel;

namespace Notebox.Data.MajorRepo
{
    public class MockSemesterRepository: ISemesterRepository
    {
        private List<MajorDbModel> _majors;
        private int _id;

        public MockSemesterRepository()
        {
            _majors = new List<MajorDbModel>();
            for(int i = 1; i < 21; i++)
            {
                _majors.Add(new MajorDbModel
                    {
                        Id = i,
                        Name = $"Automatyka i Robotyka{i}",
                        OwnerId = i++,
                        City = "Szczecin",
                        School = "Zachodniopomorski Uniwersytet Technologiczny",
                        StartYear = 2014,
                        EndYear = 2018
                    });
                _majors.Add(new MajorDbModel
                    {
                        Id = i,
                        Name = $"Inżynieria Cyfryzacji{i}",
                        OwnerId = i++,
                        City = "Szczecin",
                        School = "Zachodniopomorski Uniwersytet Technologiczny",
                        StartYear = 2014,
                        EndYear = 2018
                    });
                _majors.Add(new MajorDbModel
                {
                    Id = i,
                    Name = $"Finanse i Rachunkowość{i}",
                    OwnerId = i,
                    City = "Szczecin",
                    School = "Uniwersytet Szczeciński",
                    StartYear = 2015,
                    EndYear = 2018
                });
            }
        }

        public async Task<MajorDbModel> CreateMajorAsync(MajorDbModel major)
        {
            major.Id = _id++;
            _majors.Add(major);
            return major;
        }

        public async Task<List<MajorDbModel>> ReadMajorsAsync()
        {
            return _majors;
        }

        public async Task<List<MajorDbModel>> ReadMajorsByUserIdAsync(int userId)
        {
            return _majors.Where(m => m.OwnerId.Equals(userId)).ToList();
        }

        public async Task<MajorDbModel> ReadMajorAsync(int id)
        {
            return _majors.SingleOrDefault(m => m.Id.Equals(id));
        }

        public async Task UpdateMajorAsync(MajorDbModel major)
        {
            var majorDb = _majors.SingleOrDefault(x => x.Id.Equals(major.Id));

            majorDb.Name = major.Name;
            majorDb.OwnerId = major.OwnerId;
            majorDb.City = major.City;
            majorDb.School = major.School;
            majorDb.StartYear = majorDb.StartYear;
            majorDb.EndYear = major.EndYear;
        }

        public async Task DeleteMajorAsync(int id)
        {
            var removedMajor = _majors.SingleOrDefault(m => m.Id.Equals(id));
            _majors.Remove(removedMajor);
        }

        public Task<SemesterDbModel> CreateSemesterAsync(SemesterDbModel semester)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SemesterDbModel>> ReadSemestersAsync(int? count = null, int? skip = null)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SemesterDbModel>> ReadSemestersByMajorIdAsync(int majorId)
        {
            throw new System.NotImplementedException();
        }

        public Task<SemesterDbModel> ReadSemesterAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateSemesterAsync(SemesterDbModel major)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteSemesterAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
