using Microsoft.AspNetCore.Http;
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
    }
}
