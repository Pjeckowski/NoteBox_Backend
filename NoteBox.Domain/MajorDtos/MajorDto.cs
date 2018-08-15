using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NoteBox.Domain.MajorDtos
{
    public class MajorDto
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
    }
}
