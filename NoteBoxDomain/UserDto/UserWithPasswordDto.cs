namespace NoteBoxDomain.UserDto
{
    public class UserWithPasswordDto : IUserWithPasswordDto
    {
        public uint ID { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
