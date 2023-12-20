using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQuanLyResort.Identity
{
    public class AppUser : IdentityUser
    {
        public string CCCD { get; set; }
        public string Gmail { get; set; }
        public string Address { get; set; }

    }
}