using System.ComponentModel.DataAnnotations;

namespace Notebox.DBModels.NotesDataModel
{
    public class TextNoteContentDbModel
    {
        public int Id { get; set; }
        [Required]
        public int NoteId { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
