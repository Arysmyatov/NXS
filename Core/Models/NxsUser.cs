using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace NXS.Core.Models
{
    public class NxsUser : IdentityUser
    {   
        // Extended Properties
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public ParentRegion ParentRegion { get; set; }
    }
}