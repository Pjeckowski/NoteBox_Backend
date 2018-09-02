namespace Notebox.Data.Contract.SemesterData
{
    public interface ISemesterDataContextFactory
    {
        ISemesterDataContext GetSemesterDataContext();
    }
}
