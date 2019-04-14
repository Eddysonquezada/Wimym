namespace Wimym.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using Wimym.Web.Data.DbHelper;

    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser, ISoftDeleted
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

      //  public string AboutUs { get; set; }

        public string Image { get; set; }

      //  public string SeoUrl { get; set; }

        public bool Deleted { get; set; }

        public Owner Owner { get; set; }
    }
}
