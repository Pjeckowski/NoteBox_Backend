using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notebox.Data.Contract.MajorData;
using Notebox.Data.Contract.SemesterData;
using Notebox.DBModels.MajorDataModel;
using Notebox.DBModels.SemesterDataModel;

namespace Notebox.Data.SemesterRepo
{
    public class SemesterRepository: ISemesterRepository
    {
        private readonly ISemesterDataContextFactory _semesterDataContextFactory;

        public SemesterRepository(ISemesterDataContextFactory semesterDataContextFactory)
        {
            _semesterDataContextFactory = semesterDataContextFactory;
        }

        //public async Task UpdateMajorAsync(MajorDbModel major)
        //{
        //    using (var context = _majorDataContextFactory.GetMajorDataContext())
        //    {
        //        var majorDb = await context.Majors.SingleOrDefaultAsync(m => m.Id.Equals(major.Id));
        //        var majorToUser = await context.MajorsToUsers.SingleOrDefaultAsync(mtu =>
        //            mtu.MajorId.Equals(majorDb.Id) && mtu.UserId.Equals(major.OwnerId));

        //        majorDb.Name = major.Name;
        //        majorDb.OwnerId = major.OwnerId;
        //        majorDb.City = major.City;
        //        majorDb.School = major.School;
        //        majorDb.StartYear = major.StartYear;
        //        majorDb.EndYear = major.EndYear;

        //        majorToUser.MajorId = majorDb.Id;
        //        majorToUser.UserId = majorDb.OwnerId;

        //        context.SaveChanges();
        //    }
        //}

        //public async Task<List<MajorDbModel>> ReadMajorsAsync()
        //{

        //}
        
        //public async Task<List<MajorDbModel>> ReadMajorsByUserIdAsync(int userId)
        //{
        //    using (var context = _majorDataContextFactory.GetMajorDataContext())
        //    {
        //        //getting all user's majors ids
        //        var majorsToUser = context.MajorsToUsers.Where(mtu => mtu.UserId.Equals(userId));
        //        var majorIds = new List<int>();

        //        foreach (var majorToUser in majorsToUser)
        //        {
        //            majorIds.Add(majorToUser.MajorId);
        //        }

        //        //reading all the majors that ids are on the list
        //        return await context.Majors.Where(m => majorIds.Contains(m.Id)).ToListAsync();
        //    }
        //}

        //public async Task<MajorDbModel> ReadMajorAsync(int id)
        //{
        //    using (var context = _majorDataContextFactory.GetMajorDataContext())
        //    {
        //        return await context.Majors.SingleOrDefaultAsync(m => m.Id.Equals(id));
        //    }
        //}

        //public async Task DeleteMajorAsync(int id)
        //{
        //    using (var context = _majorDataContextFactory.GetMajorDataContext())
        //    {
        //        var removedMajor = await context.Majors.SingleOrDefaultAsync(m => m.Id.Equals(id));
        //        var removedMajorsToUsers = context.MajorsToUsers.Where(mtu => mtu.MajorId.Equals(id));

        //        context.Majors.Remove(removedMajor);
        //        context.MajorsToUsers.RemoveRange(removedMajorsToUsers);

        //        context.SaveChanges();
        //    }
        //}

        public async Task<SemesterDbModel> CreateSemesterAsync(SemesterDbModel semester)
        {
            using (var context = _semesterDataContextFactory.GetSemesterDataContext())
            {
                await context.Semesters.AddAsync(semester);

                var addedsemester = await context.Semesters.SingleOrDefaultAsync(
                    m => m.MajorId.Equals(semester.MajorId) &&
                         m.Semester.Equals(semester.Semester));

                context.SaveChanges();
                return addedsemester;
            }
        }

        public async Task<List<SemesterDbModel>> ReadSemestersAsync(int? count = null, int? skip = null)
        {
            using (var context = _semesterDataContextFactory.GetSemesterDataContext())
            {
                if(count == null)
                return await context.Semesters.Skip(new Func<int>(() => skip ?? 0)())
                    .ToListAsync();
                return await context.Semesters.Skip(new Func<int>(() => skip ?? 0)()).Take((int) count)
                    .ToListAsync();
            }
        }

        public async Task<List<SemesterDbModel>> ReadSemestersByMajorIdAsync(int majorId)
        {
            using (var context = _semesterDataContextFactory.GetSemesterDataContext())
            {
                return await context.Semesters.Where(s => s.MajorId.Equals(majorId)).ToListAsync();
            }
        }

        public Task<SemesterDbModel> ReadSemesterAsync(int id)
        {
            using (var context = _semesterDataContextFactory.GetSemesterDataContext())
            {
                return context.Semesters.SingleOrDefaultAsync(s => s.Id.Equals(id));
            }
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
