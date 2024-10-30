using LibraryBookManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LibraryBookManagement.Models;
using LibraryBookManagement.Models.Dtos;

namespace LibraryBookManagement.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class LibraryController : ControllerBase
{
    private readonly ApplicationDbContext dbContext;
    private Guid bookId;

    public LibraryController(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    [HttpGet]
    public async Task<IActionResult> GetBooks(
        [FromQuery]bool? available=null,
        [FromQuery]string genre=null,
        [FromQuery]string search=null,
        [FromQuery]int page=1,
        [FromQuery]int pageSize=10)
    {
        var query =dbContext.Books.AsQueryable();
        if (available.HasValue)
        {
            query = query.Where(x => x.IsAvailable == available);
        }
        if (!string.IsNullOrEmpty(genre))
        {
            query = query.Where(x => x.Genre == genre);
        }
        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.Title.Contains(search)||x.Author.Contains(search));
        }

        var paginatedList=await query.Skip((page-1)*pageSize).Take(pageSize).ToListAsync();
        var response = new PaginatedListResponse<Book>
        {
            TotalItems = query.Count(),
            PageSize = pageSize,
            CurrentPage = page,
            Books = paginatedList
        };
        return Ok(response);
           
           
            
    }
    //POST /api/books
    [HttpPost]
    public async Task<IActionResult> AddBook([FromBody] Book book)
    {
        if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBooks), new {id=book.Id},book);
    }
    //POST /api/books/{id}/checkout
    [HttpPost("{id}/checkout")]
    public async Task<IActionResult> CheckoutBook([FromRoute]Guid id,[FromBody] CheckoutDto checkoutDto)
    {
        var book=await dbContext.Books.FindAsync(id);
        if (book is null)
        {
            return NotFound();
        }
        if(book.IsAvailable == false)
        {
            return Conflict("Book is already checked out");
        }
        var borrowingRecord = new BorrowingRecord
        {
            BookId = book.Id,
            BorrowerName = checkoutDto.BorrowerName,
            BorrowDate = checkoutDto.BorrowDate
        };
        dbContext.BorrowingRecords.Add(borrowingRecord);
        book.IsAvailable = false;
        await dbContext.SaveChangesAsync();
        return Ok(book);
           

    }
    [HttpPost("{id}/return")]
    public async Task<IActionResult> ReturnBook([FromRoute] Guid id, [FromBody] ReturnDto returnDto)
    {
        var book = await dbContext.Books.FindAsync(id);
        if (book is null)
        {
            return NotFound();
        }
        var borrowingRecord = await dbContext.BorrowingRecords.Where(borrow => borrow.BookId == id && borrow.ReturningDate == null).FirstOrDefaultAsync();
        if (borrowingRecord == null)
        {
            return BadRequest("Book is not borrowed");
        }
        borrowingRecord.ReturningDate = returnDto.ReturningDate;
        dbContext.BorrowingRecords.Update(borrowingRecord);
        book.IsAvailable = true;
        await dbContext.SaveChangesAsync();
        return Ok();
    }
    [HttpGet("{id}/history")]
    public async Task<IActionResult> GetBorrowingHistory([FromRoute] Guid id)
    {
        var book=await dbContext.Books.FindAsync(id);
        if (book is null)
        {
            return NotFound();
        }
        var borrowingRecords = await dbContext.BorrowingRecords.Where(borrow => borrow.BookId==id).ToListAsync();

        var response = new BorrowingHistoryDto
        {
            BookId = id,
            BookTitle = book.Title,
            BorrowingRecords = borrowingRecords
        };
        return Ok(response);
    }
           
}
}
