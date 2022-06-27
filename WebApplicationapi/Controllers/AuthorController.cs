using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApplicationapi.modesl;

namespace WebApplicationapi.Controllers
{
    [Route("api/Author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public static List<Author> Authors = new List<Author>()
        {
             new Author(){AuthorId=10, AuthorName="EJLAL",AuthorLevel="1"},
                new Author(){AuthorId=20, AuthorName="OLA",AuthorLevel="1"},
        };

        [EnableQuery]
        [HttpGet]
        public List<Author> GetAll()
        {
            return Authors;
        }

        [HttpGet("{Id}")]
        public IActionResult GetAuthorById(int Id)
        {
            var CurAuthor = Authors.Where(x => x.AuthorId == Id).FirstOrDefault();
            if (CurAuthor == null)
            {
                return NotFound(new
                {
                    ErrorCode = 501,
                    ErrorMessage = "author not found"

                });
            }
            return Ok(CurAuthor);

        }
        [HttpPut]
        public IActionResult updateAuthor(Author newAuthor)
        {
            if (string.IsNullOrWhiteSpace(newAuthor.AuthorName))
            {
                BadRequest(new
                {
                    ErrorCode = 502,
                    ErrorMessage = "name is not vaild"
                });
            }
            var CurAuthor=Authors.Where(x => x.AuthorId == newAuthor.AuthorId).FirstOrDefault();
            if(CurAuthor == null)
            {
                NotFound(new
                {
                    ErrorCode = 501,
                    ErrorMessage = "author not found"
                });
            }
            CurAuthor.AuthorName = newAuthor.AuthorName;
            CurAuthor.AuthorLevel= newAuthor.AuthorLevel;
            return Ok("edit successfully");
        }
        [HttpDelete("{AuthorId}")]
        public IActionResult deleteAuthor(int AuthorId)
        {

            var CurAuthor = Authors.Where(x => x.AuthorId == AuthorId).SingleOrDefault();
            if (CurAuthor == null)
            {
                return NotFound(new
                {
                    ErrorCode = 501,
                    ErrorMessage = "author not found"

                });
            }
            //chect if Author has book
            if(BookController.BookList.Any(x=>x.AuthorId== AuthorId))
            {
                return BadRequest("this author has dependency");
            }
            Authors.Remove(CurAuthor);
            return NoContent();
        }

    }

}

