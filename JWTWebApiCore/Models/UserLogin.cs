using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTWebApiCore.Models
{
    public class UserLogin
    {
        public string User { get; set; }
        public string Pwd { get; set; }
    }
}
