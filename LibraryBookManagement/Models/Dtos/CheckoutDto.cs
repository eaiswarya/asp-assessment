using System.ComponentModel.DataAnnotations;

namespace LibraryBookManagement.Models.Dtos
{
public class CheckoutDto
{
    [MaxLength(100)]
    public required string BorrowerName { get; set; }
    public required DateTime BorrowDate { get; set; }
}
}
