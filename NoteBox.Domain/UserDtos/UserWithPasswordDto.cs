namespace NoteBox.Domain.UserDtos
{
    public class UserWithPasswordDto : IUserWithPasswordDto
    {
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
