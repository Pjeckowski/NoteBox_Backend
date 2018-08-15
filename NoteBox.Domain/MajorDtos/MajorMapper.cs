using System;
using Notebox.DBModels.MajorDataModel;

namespace NoteBox.Domain.MajorDtos
{
    public class MajorMapper: IMajorMapper
    {
        public MajorDto DbModelToDto(MajorDbModel majorDb)
        {
            return new MajorDto
            {
                Id = majorDb.Id,
                Name = majorDb.Name,
                City = majorDb.City,
                School = majorDb.School,
                OwnerId = majorDb.OwnerId,
                StartYear = majorDb.StartYear,
                EndYear = majorDb.EndYear
            };
        }

        public MajorDbModel DtoToDbModel(MajorDto majorDto)
        {
            return new MajorDbModel()
            {
                Id = majorDto.Id,
                Name = majorDto.Name,
                City = majorDto.City,
                School = majorDto.School,
                OwnerId = majorDto.OwnerId,
                StartYear = majorDto.StartYear,
                EndYear = majorDto.EndYear
            };
        }
    }
}
