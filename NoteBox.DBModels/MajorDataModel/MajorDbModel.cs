using System.ComponentModel.DataAnnotations;

namespace Notebox.DBModels.MajorDataModel
{
    public class MajorDbModel : IMajorDbModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int StartYear { get; set; }
        [Required]
        public int EndYear { get; set; }
        [Required]
        public string School { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public string Description { get; set; }
    }
}
