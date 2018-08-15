namespace NoteBox.Domain.UserDtos
{
    public interface IUserWithPasswordDto
    {
        string Password { get; }
        string Nick { get; }
        string Email { get; }
    }
}
