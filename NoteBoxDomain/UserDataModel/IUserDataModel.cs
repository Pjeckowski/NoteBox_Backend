namespace NoteBoxDomain.UserDataModel
{
    public interface IUserDataModel
    {
        uint ID { get; set; }
        string Nick { get; set; }

        string Email { get; set; }

        string Password { get; set; }
    }
}
