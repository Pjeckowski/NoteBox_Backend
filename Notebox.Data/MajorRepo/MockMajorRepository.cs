using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Notebox.Data.Contract.MajorData;
using Notebox.DBModels.MajorDataModel;

namespace Notebox.Data.MajorRepo
{
    public class MockMajorRepository: IMajorRepository
    {
        private List<MajorDbModel> _majors;
        private int _id;

        public MockMajorRepository()
        {
            _majors = new List<MajorDbModel>()
            {
                new MajorDbModel
                {
                    Id = 1,
                    Name = "Automatyka i Robotyka",
                    OwnerId = 1,
                    City = "Szczecin",
                    School = "Zachodniopomorski Uniwersytet Technologiczny",
                    StartYear = 2014,
                    EndYear = 2018
                },
                new MajorDbModel
                {
                    Id = 2,
                    Name = "Inżynieria Cyfryzacji",
                    OwnerId = 2,
                    City = "Szczecin",
                    School = "Zachodniopomorski Uniwersytet Technologiczny",
                    StartYear = 2014,
                    EndYear = 2018
                },
                new MajorDbModel
                {
                    Id = 3,
                    Name = "Finanse i Rachunkowość",
                    OwnerId = 3,
                    City = "Szczecin",
                    School = "Uniwersytet Szczeciński",
                    StartYear = 2015,
                    EndYear = 2018
                },
            };
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
    }
}
