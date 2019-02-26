using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loginApp.Models
{
    public class User
    {
        public int _id { get; set; }
        public string _mail { get; set; }
        public DateTime _birthDay { get; set; }
        public string _name { get; set; }
        public string _phone { get; set; }
        public string _gender { get; set; }
    }
}
