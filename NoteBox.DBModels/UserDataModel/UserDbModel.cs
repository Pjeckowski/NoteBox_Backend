using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text.RegularExpressions;

namespace Notebox.DBModels.UserDataModel
{
    public class UserDbModel : IUserDbModel
    {
        public int Id { get; set; }
        [Required]
        public string Nick { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
