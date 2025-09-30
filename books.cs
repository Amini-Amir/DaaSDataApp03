using System.ComponentModel.DataAnnotations;

namespace BlazorApp03.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? PublishedDate { get; set; }
    }
}