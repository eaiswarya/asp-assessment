using System.ComponentModel.DataAnnotations;

namespace LibraryBookManagement.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public required string Title { get; set; }
        [MaxLength(100)]
        public required string Author { get; set; }
        [RegularExpression(@"^(978[- ]?\d{1,5}[- ]?\d{1,7}[- ]?\d{1,6}[- ]?\d|97[89][0-9]{10})$")]
        public required string ISBN { get; set; }
        public string Genre { get; set; }
        [DateInPast]
        public required DateTime PublishedDate { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        public bool IsAvailable { get; set; }
    }
}
