using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamCode.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3)]

        public string? Key { get; set; }
        [StringLength(maximumLength: 50, MinimumLength = 3)]

        public string? Value { get; set; }
        
    }
}
