using System.Collections.Generic;
namespace JwtApp.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel(){Username="json",EmailAddress="j@gmail.com",Password = "Mypassword",GivenName="json",Surname="brayan",Role="Administrator" },
            new UserModel(){Username="Ellie",EmailAddress="e@gmail.com",Password = "Mypassword",GivenName="ellie",Surname="brellie",Role="Seller" },
        };
    }
}
