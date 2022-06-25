using Microsoft.AspNetCore.JsonPatch;
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

        public string update(user edituser)
        {
            var CurUser =users.Where(x => x.id == edituser.id).SingleOrDefault();
            if (string.IsNullOrWhiteSpace(CurUser.name)){
                return "name is empty";
            }
            CurUser.name = edituser.name;
            return "edit succesfully";
        }

        public string UpDateUserPartially(int UserId, JsonPatchDocument userPatch)
        {
            var CurUser = users.Where(x => x.id == UserId).SingleOrDefault();
            if (CurUser ==null )
            {
                return "not found";
            }

            userPatch.ApplyTo(CurUser);
            return "edit succesfully";
        }

        public string DeleteUser(int UserId)
        {
            var CurUser = users.Where(x => x.id == UserId).SingleOrDefault();
            if (CurUser == null)
            {
                return "not found";
            }
            users.Remove(CurUser);
            return "deleted succesfuly";
        }
    }
}
