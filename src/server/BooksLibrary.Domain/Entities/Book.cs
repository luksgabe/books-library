namespace BooksLibrary.Domain.Entities
{
    public class Book : Entity
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string? Description { get; private set; }
        public string Category { get; private set; }
        public string Link { get; private set; }
        public virtual BookImage? Image { get; private set; }

        public Book(string title, string author,string? description, string category, string link)
        {
            Title = title;
            Author = author;
            Description = description;
            Category = category;
            Link = link;
        }

        public void SetImage(BookImage image)
        {
            Image = image;
        }
    }
}
