namespace NoteBoxDomain.UserDto
{
    public class UserDto :IUserDto
    {
        public  int ID { get; set; }
        public string Nick { get; set; }
        public string Email { get; set; }
    }
}
