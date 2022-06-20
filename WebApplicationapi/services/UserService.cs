using WebApplicationapi.modesl;

namespace WebApplicationapi.services
{
    public class UserService : IuserServices
    {
        public IQueryable<user> RetrieveAllUser()
        {
            return new List<user>
            { new user
            {
                id = 1,
                name="ejlal",
                location="sanaa"
            },
            new user
            {
                id = 2,
                name="ejlal",
                location="sanaa"
            },
            new user
            {
                id = 3,
                name="ejlal",
                location="sanaa"
            }

            }.AsQueryable();
        }
    }
}
