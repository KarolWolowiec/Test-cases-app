using System.ComponentModel.DataAnnotations;

namespace Test.Data.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public List<TestCase> TestCases { get; set; } = new()
    }
}
