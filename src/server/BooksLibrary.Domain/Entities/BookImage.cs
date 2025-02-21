namespace BooksLibrary.Domain.Entities
{
    public class BookImage : Entity
    {
        public string Thumbnail { get; private set; }
        public string SmallThumbnail { get; private set; }
        public int BookId { get; private set; }
        public virtual Book Book { get; private set; }

        public BookImage(string thumbnail, string smallThumbnail)
        {
            Thumbnail = thumbnail;
            SmallThumbnail = smallThumbnail;
        }

        public void SetBookId(int bookId)
        {
            BookId = bookId;
        }
    }
}
