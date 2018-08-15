namespace NoteBox.Domain.UserDtos
{
    public class UserDto :IUserDto
    {
        public  int Id { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
    }
}
