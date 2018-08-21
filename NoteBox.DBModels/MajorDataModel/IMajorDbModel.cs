namespace Notebox.DBModels.MajorDataModel
{
    public interface IMajorDbModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string City { get; set; }
        int StartYear { get; set; }
        int EndYear { get; set; }
        string School { get; set; }
        int OwnerId { get; set; }
    }
}
