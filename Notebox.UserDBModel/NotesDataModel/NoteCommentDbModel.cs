using System;
using System.ComponentModel.DataAnnotations;

namespace Notebox.DBModels.NotesDataModel
{
    public class NoteCommentDbModel
    {
        public int Id { get; set; }
        [Required]
        public int NoteId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int Onions { get; set; }
    }
}
