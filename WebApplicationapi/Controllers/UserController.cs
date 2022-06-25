using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApplicationapi.modesl;
using WebApplicationapi.services;

namespace WebApplicationapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IuserServices userServices;

        public UserController(IuserServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IQueryable<user>> GetAll()
        {
            IQueryable<user> retrievedUser =
                this.userServices.RetrieveAllUser();

            return Ok(retrievedUser);
        }
        [HttpGet("{id}")]
        public ActionResult getuserbyid(int id)
        {
            return Ok(this.userServices.GetDatabyid(id));
        }
        [HttpPost]
        public ActionResult addUser(user newuser)
        {
            this.userServices.AddUser(newuser);
            if (string.IsNullOrWhiteSpace(newuser.name))
            {
               // return BadRequest(new { ErrorCode - 501, ErrorMessage - "should enter user name" };
                return BadRequest("Inavlid empty user name");
            }

            return Ok("has add new user");
        }
        [HttpPut]
        public IActionResult updateUser( user newuser )
        {
            return Ok(this.userServices.update(newuser));
        }

        [HttpPatch("{Id}")]
        public IActionResult UpdateUserPartically(int Id,JsonPatchDocument userPatch)
        {
            return Ok(userServices.UpDateUserPartially(Id, userPatch));
        }

        [HttpDelete("{id}")]
        public IActionResult deleteUser(int id)
        {
            return Ok(userServices.DeleteUser(id));
        }

       
    }
}
