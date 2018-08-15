using Notebox.DBModels.MajorDataModel;

namespace NoteBox.Domain.MajorDtos
{
    public interface IMajorMapper
    {
        MajorDto DbModelToDto(MajorDbModel majorDb);
        MajorDbModel DtoToDbModel(MajorDto majorDto);
    }
}
