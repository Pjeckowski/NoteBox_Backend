using System.ComponentModel.DataAnnotations;

namespace Notebox.DBModels.SemesterDataModel
{
    public class SemesterDbModel
    {
        public int Id { get; set; }

        [Required]
        public int Semester { get; set; }

        [Required]
        public int MajorId { get; set; }
    }
}
