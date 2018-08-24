using System;
using System.Collections.Generic;

namespace NoteBox.Domain.SubjectDtos
{
    public class SubjectDto
    {
        public int Id { get; set; }

        public int SemesterId { get; set; }

        public string MajorName { get; set; }

        public string LectureType { get; set; }

        public string Name { get; set; }

        public string Lecturer { get; set; }

        public List<SubjectNotes> Notes { get; set; }

        public string NotesUrl { get; set; }
    }

    public class SubjectNotes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Added { get; set; }

        public int Onions { get; set; }

        public string NoteUrl { get; set; }

    }
}
