using System.Collections.Generic;

namespace NoteBox.Domain.SemesterDtos
{
    public class SemesterDto
    {
        public int Id { get; set; }

        public int MajorSequenceId { get; set; }

        public int MajorId { get; set; }

        public List<SemesterSubject> Subjects { get; set; }

        public string SubjecsDetailsUrl { get; set; }
    }

    public class SemesterSubject
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        public string SubjectUrl { get; set; }
    }
}
