using System;
using System.Collections.Generic;
using System.Text;

namespace Wimym.Model.Shared
{
    public class UserDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public bool Deleted { get; set; }

        public string Image { get; set; }

        // /#/users/eduardo-15
        public string SeoUrl { get; set; }
    }

    public class UserPartialDto
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string AboutUs { get; set; }

        public string Image { get; set; }
    }
}
