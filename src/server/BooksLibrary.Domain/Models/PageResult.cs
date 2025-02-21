namespace BooksLibrary.Domain.Models
{
    public class PageResult<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Items { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
