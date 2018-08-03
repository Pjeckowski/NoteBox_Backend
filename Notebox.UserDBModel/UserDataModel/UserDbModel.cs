namespace Notebox.UserDBModel.UserDataModel
{
    public class UserDbModel : IUserDbModel
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
