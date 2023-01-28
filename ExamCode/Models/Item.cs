using ExamCode.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamCode.Models
{
    public class Item:BaseEntity
    {
        [StringLength(maximumLength: 150, MinimumLength = 3)]
        public string? Desc { get; set; }
        [StringLength(maximumLength: 150, MinimumLength = 3)]

        public string? ImageUrl { get; set; }

        public Category? Category { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [NotMapped]
        public IFormFile? formFile { get; set; }
    }
}
