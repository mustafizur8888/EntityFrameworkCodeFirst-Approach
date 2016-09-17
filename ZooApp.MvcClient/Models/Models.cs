using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ZooApp.MvcClient.Models
{
    public class ApplicationUser : IdentityUser
    {
       
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        
    }
}