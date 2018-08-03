namespace Notebox.UserDBModel.UserDataModel
{
    public interface IUserDbModel
    {
        int Id { get; set; }
        string Nick { get; set; }
        string Email { get; set; }
        string Password { get; set; }
    }
}
