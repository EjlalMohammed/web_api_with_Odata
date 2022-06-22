using Microsoft.AspNetCore.Mvc;
using WebApplicationapi.modesl;

namespace WebApplicationapi.services
{
    public interface IuserServices
    {
        IQueryable<user> RetrieveAllUser();

        public List<user> GetDatabyid(int id);

        public string AddUser(user user);

        public string update(user edituser);
    }
}
