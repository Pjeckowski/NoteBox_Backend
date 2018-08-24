using System;

namespace NoteBox.Domain.NotesDtos
{
    public class TextNoteDto
    {
        public int Id { get; set; }

        public string Tittle { get; set; }

        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public int Onions { get; set; }

        public string CommentsUrl { get; set; }
    }
}
