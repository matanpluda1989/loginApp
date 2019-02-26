using loginApp.DAL;
using loginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace loginApp.Controllers
{
    public class UserDetailesController : ApiController
    {

        UsersDal _usersDal = new UsersDal();

        User[] _users = new User[]
       {
            new User { _id = 1, _name = "yossef", _birthDay = new DateTime(1985,12,10 ), _phone = "036571734" ,_gender = "male", _mail =  "zozo@gmail.com"},
            new User { _id = 2, _name = "moshe", _birthDay = new DateTime(1985,12,10 ), _phone = "036571734" ,_gender = "female", _mail =  "zozo@gmail.com"},
            new User { _id = 3, _name = "nahum", _birthDay = new DateTime(1985,12,10 ), _phone = "036571734" ,_gender = "male", _mail =  "zozo@gmail.com"}
       };
        
        public IEnumerable<User> GetAllUsers()
        {
            return this._usersDal.GetAll();
        }

        public IHttpActionResult GetUser(int id)
        {
            var User = _users.FirstOrDefault((p) => p._id == id);
            if (User == null)
            {
                return NotFound();
            }
            return Ok(User);
        }

        public IHttpActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            this._usersDal.Insert(user);
            return Ok("שמירה בוצעה בהצלחה");
        }
    }
}
