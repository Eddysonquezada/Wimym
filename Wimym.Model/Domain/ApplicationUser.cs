using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Wimym.Model.Domain.DbHelper;

namespace Wimym.Model.Domain
{
    public class ApplicationUser : IdentityUser, ISoftDeleted
    {
        public string Name { get; set; }
        public string Lastname { get; set; }

        public string AboutUs { get; set; }
        public string Image { get; set; }

        // /#/users/eduardo-15
        public string SeoUrl { get; set; }

        public bool Deleted { get; set; }
    }
}
