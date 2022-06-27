namespace WebApplicationapi.modesl
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }

        public int PublishYear { get; set; }

        public int PaperCount { get; set; }

        public int AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
