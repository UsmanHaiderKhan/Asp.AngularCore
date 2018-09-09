using Microsoft.AspNetCore.Identity;

namespace Asp.AngularCore.git.Data.Entities
{
    public class StoreUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }



    }
}
