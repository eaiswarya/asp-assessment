﻿
namespace LibraryBookManagement.Models.Dtos
{
    public class PaginatedListResponse<T> where T : class
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<T> Items { get; set; }
        public List<Book> Books { get; internal set; }
    }

    public class PaginatedListResponse : PaginatedListResponse<Book>
    {
        public IEnumerable<Book> Books => Items;
    }
}
