using System;
using System.Collections.Generic;
using System.Text;

namespace Wimym.Domain.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [MaxLength(250)]
        public string AboutMe { get; set; }

        [MaxLength(100)]
        public string Image { get; set; }

        [MaxLength(50)]
        public string SeoUrl { get; set; }

        public bool State { get; set; }
    }
}
