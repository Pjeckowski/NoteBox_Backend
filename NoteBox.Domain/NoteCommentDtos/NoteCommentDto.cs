using System;

namespace NoteBox.Domain.NoteCommentDtos
{
    public class NoteCommentDto
    {
        public int Id { get; set; }

        public int NoteId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public DateTime Date { get; set; }

        public string Content { get; set; }

        public int Onions { get; set; }
    }
}
