using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notebox.Data.Contract.MajorData;
using Notebox.DBModels.MajorDataModel;

namespace Notebox.Data.MajorRepo
{
    public class MajorRepository: IMajorRepository
    {
        private readonly IMajorDataContextFactory _majorDataContextFactory;

        public MajorRepository(IMajorDataContextFactory majorDataContextFactory)
        {
            _majorDataContextFactory = majorDataContextFactory;
        }

        public async Task<MajorDbModel> CreateMajorAsync(MajorDbModel major)
        {
            using (var context = _majorDataContextFactory.GetMajorDataContext())
            {
                await context.Majors.AddAsync(major);

                var addedMajor =  await context.Majors.SingleOrDefaultAsync(
                    m => m.Name.Equals(major.Name) &&
                    m.OwnerId.Equals(major.OwnerId) &&
                    m.City.Equals(major.City) &&
                    m.School.Equals(major.School) &&
                    m.StartYear.Equals(major.StartYear) &&
                    m.EndYear.Equals(major.EndYear));

                await context.MajorsToUsers.AddAsync(new MajorToUserDbModel()
                {
                    MajorId = addedMajor.Id,
                    UserId = addedMajor.OwnerId
                });

                context.SaveChanges();
                return addedMajor;
            }
        }

        public async Task UpdateMajorAsync(MajorDbModel major)
        {
            using (var context = _majorDataContextFactory.GetMajorDataContext())
            {
                var majorDb = await context.Majors.SingleOrDefaultAsync(m => m.Id.Equals(major.Id));
                var majorToUser = await context.MajorsToUsers.SingleOrDefaultAsync(mtu =>
                    mtu.MajorId.Equals(majorDb.Id) && mtu.UserId.Equals(major.OwnerId));

                majorDb.Name = major.Name;
                majorDb.OwnerId = major.OwnerId;
                majorDb.City = major.City;
                majorDb.School = major.School;
                majorDb.StartYear = major.StartYear;
                majorDb.EndYear = major.EndYear;

                majorToUser.MajorId = majorDb.Id;
                majorToUser.UserId = majorDb.OwnerId;

                context.SaveChanges();
            }
        }

        public async Task<List<MajorDbModel>> ReadMajorsAsync()
        {
            using (var context = _majorDataContextFactory.GetMajorDataContext())
            {
                return await context.Majors.ToListAsync();
            }
        }
        
        public async Task<List<MajorDbModel>> ReadMajorsByUserIdAsync(int userId)
        {
            using (var context = _majorDataContextFactory.GetMajorDataContext())
            {
                //getting all user's majors ids
                var majorsToUser = context.MajorsToUsers.Where(mtu => mtu.UserId.Equals(userId));
                var majorIds = new List<int>();

                foreach (var majorToUser in majorsToUser)
                {
                    majorIds.Add(majorToUser.MajorId);
                }

                //reading all the majors that ids are on the list
                return await context.Majors.Where(m => majorIds.Contains(m.Id)).ToListAsync();
            }
        }

        public async Task<MajorDbModel> ReadMajorAsync(int id)
        {
            using (var context = _majorDataContextFactory.GetMajorDataContext())
            {
                return await context.Majors.SingleOrDefaultAsync(m => m.Id.Equals(id));
            }
        }

        public async Task DeleteMajorAsync(int id)
        {
            using (var context = _majorDataContextFactory.GetMajorDataContext())
            {
                var removedMajor = await context.Majors.SingleOrDefaultAsync(m => m.Id.Equals(id));
                var removedMajorsToUsers = context.MajorsToUsers.Where(mtu => mtu.MajorId.Equals(id));

                context.Majors.Remove(removedMajor);
                context.MajorsToUsers.RemoveRange(removedMajorsToUsers);

                context.SaveChanges();
            }
        }
    }
}
