using Microsoft.AspNetCore.Mvc;
using WebApplicationapi.modesl;

namespace WebApplicationapi.services
{
    public class UserService : IuserServices
    {
        public static List<user> users = new List<user>() {
            new user(){id=10,name="ejlal",location="sanaa"},
            new user(){id=20,name="ola",location="sanaa"},
            new user(){id=30,name="sara",location="sanaa"}
        };

        public string AddUser(user user)
        {
             users.Add(user);
            return user.name;
           
        }

        public List<user> GetDatabyid(int Id)
        {

            return users.Where(x => x.id == Id).ToList();


        }
        public IQueryable<user> RetrieveAllUser()
        {
            return users.AsQueryable();
        }

    }
}
