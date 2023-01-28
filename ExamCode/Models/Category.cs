using ExamCode.Base;
using System.ComponentModel.DataAnnotations;

namespace ExamCode.Models
{
    public class Category:BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]

        public string Name { get; set; }
        public List<Item>? items { get; set; }
    }
}
