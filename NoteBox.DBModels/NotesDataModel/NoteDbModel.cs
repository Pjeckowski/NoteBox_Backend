using System;
using System.ComponentModel.DataAnnotations;

namespace Notebox.DBModels.NotesDataModel
{
    public class NoteDbModel
    {
        public int Id { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ContentType { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Onions { get; set; }
    }
}
