using System.ComponentModel.DataAnnotations;

namespace Test.Data.Models
{
    public class TestCase
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
