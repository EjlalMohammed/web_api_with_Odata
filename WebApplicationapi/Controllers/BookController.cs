using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationapi.modesl;

namespace WebApplicationapi.Controllers
{
    [Route("api/Author/{AuthorId}/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public static List<Book> BookList = new List<Book>(){
         new Book (){BookId=1,BookName="computer",PaperCount=100,PublishYear=2022,AuthorId=10 },
         new Book (){BookId=2,BookName="computer",PaperCount=100,PublishYear=2022,AuthorId=10  },
         new Book (){BookId=3,BookName="computer",PaperCount=100,PublishYear=2022,AuthorId=10  }

        };

        [HttpGet]
        public IActionResult AllAuthorBook(int AuthorId)
        {
            return Ok(BookList.Where(x => x.AuthorId == AuthorId).ToList());
        }

        [HttpGet("{BookId}", Name = "GetBookById")]
        public IActionResult oneBook(int AuthorId, int BookId)
        {
            var CurBook = BookList.Where(x => x.BookId == BookId && x.AuthorId == AuthorId).SingleOrDefault();
            if (CurBook == null)
            {
                return NotFound("book not found");
            }
            return Ok(CurBook);
        }
        [HttpPost]
        public IActionResult AddBook(int AuthorId, Book NewBook)
        {
            if (!AuthorController.Authors.Any(x => x.AuthorId == AuthorId))
            {
                return NotFound("Author is not founded");
            }
            if (AuthorId != NewBook.AuthorId)
            {
                return BadRequest("invalid author id");
            }
            if (BookList.Any(x => x.AuthorId == AuthorId && x.BookId == NewBook.BookId))
            {
                return Conflict("book is already exist");
            }
            BookList.Add(NewBook);
            return CreatedAtRoute(("GetBookById"), new { AuthorId = AuthorId, BookId = NewBook.BookId }, NewBook);
            // CreatedAtAction(nameof(oneBook), new  { AuthorId = AuthorId, BookId = NewBook.BookId },NewBook);
        }
        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook(int AuthorId,int bookId)
        {
            if (!AuthorController.Authors.Any(x => x.AuthorId == AuthorId))
            {
                return NotFound("Author is not founded");
            }
            var CurBook = BookList.Where(x => x.AuthorId == AuthorId && x.BookId == bookId).FirstOrDefault();
            if (CurBook==null)
            {
                return NotFound("book is not found");
            }
            BookList.Remove(CurBook);
            return NoContent();

        }
    }
}
