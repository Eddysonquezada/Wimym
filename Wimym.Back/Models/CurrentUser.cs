using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wimym.Back.Models
{
    public class CurrentUser
    {
        using System;
using System.Collections.Generic;
using System.Text;

        public string UserId { get; set; }
        public string Name { get; set; }
        public string SeoUrl { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
    }
}
