namespace BookLibrary.Api.Models
{
    public class GetBooksRequest
    {
        public string? SearchParam { get; set; } = null!;
        public int Page { get; set; }
        public int Size { get; set; }

    }
}
