namespace WebApplicationapi.modesl
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorLevel { get; set; }

        public List<Book> Books { get; set; }
    }
}
