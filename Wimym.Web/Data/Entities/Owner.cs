namespace Wimym.Web.Data.Entities
{
    using System.Collections.Generic;
    using Wimym.Web.Data.DbHelper;

    public class Owner : ISoftDeleted
    {
        public long Id { get; set; }

        public string Rnc { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string AboutUs { get; set; }

        public string Image { get; set; }

        public bool Deleted { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
