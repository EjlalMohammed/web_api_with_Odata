using Microsoft.AspNetCore.JsonPatch;
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

        public string UpDateUserPartially(int  UserId,JsonPatchDocument userPatch);

        public string DeleteUser(int UserId);
    }
}
