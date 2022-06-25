using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationapi.modesl;

namespace WebApplicationapi.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public static List<Author> Authors = new List<Author>()
        {
             new Author(){AuthorId=10, AuthorName="EJLAL",AuthorLevel="1"},
                new Author(){AuthorId=20, AuthorName="OLA",AuthorLevel="1"},
        };


        [HttpGet]
        public List<Author> GetAll()
        {
            return Authors;
        }

        [HttpGet("{Id}")]
        public IActionResult GetStudentById(int Id)
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
        [HttpDelete("{AuthorId}")]
        public IActionResult deleteauther(int AuthorId)
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
            Authors.Remove(CurAuthor);
            return NoContent();
        }
    }

}

