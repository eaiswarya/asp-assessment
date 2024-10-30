namespace LibraryBookManagement.Models.Dtos
{
public class BorrowingHistoryDto
{
    public Guid BookId { get; set; }
    public string BookTitle { get; set; }
    public List<BorrowingRecord> BorrowingRecords { get; set; }
}
}
