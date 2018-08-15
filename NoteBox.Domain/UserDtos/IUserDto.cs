namespace NoteBox.Domain.UserDtos
{
    public interface IUserDto
    {
        int Id { get; set; }
        string Nick { get; set; }
        string Email { get; set; }
    }
}
