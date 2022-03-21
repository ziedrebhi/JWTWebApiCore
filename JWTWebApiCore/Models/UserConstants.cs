using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTWebApiCore.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "zrebhi_admin", EmailAddress = "zrebhi_admin@mail.com", Password = "123", GivenName = "Zrebhi", Surname = "Z", Role = "Admin" },
            new UserModel() { Username = "zrebhi_user", EmailAddress = "zrebhi_user@mail.com", Password = "123", GivenName = "Zrebhi 2", Surname = "Z", Role = "User" },
        };
    }
}
