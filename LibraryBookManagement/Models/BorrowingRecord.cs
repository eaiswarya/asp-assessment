﻿using System.ComponentModel.DataAnnotations;

namespace LibraryBookManagement.Models
{
public class BorrowingRecord
{
    public Guid Id { get; set; }
    public Guid BookId { get; set; }
    public required DateTime BorrowDate { get; set; }
    public DateTime? ReturningDate { get; set; }
    [MaxLength(100)]
    public required string BorrowerName { get; set; }
}
}
