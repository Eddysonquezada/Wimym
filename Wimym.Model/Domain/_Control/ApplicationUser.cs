namespace Wimym.Model.Domain._Control
{
    using Microsoft.AspNetCore.Identity;
    using Model.Domain.DbHelper;


    public class ApplicationUser : IdentityUser, ISoftDeleted
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string AboutMe { get; set; }

        public string Image { get; set; }
             
        public string SeoUrl { get; set; }

        public bool Deleted { get; set; }

        //public  Owner Owner { get; set; }
        //public int OwnerId { get; set; }

        public  Shop Shop { get; set; }
        public int ShopId { get; set; }

        public UserType UserType { get; set; }
        public int UserTypeId { get; set; }

        //public int StatusId { get; set; }

        //public string AccessToken { get; set; }

        //public string TokenType { get; set; }

        //public DateTime TokenExpires { get; set; }

        //public string Password { get; set; }

        //public bool IsRemembered { get; set; }

       // public ICollection<Operation> Operations { get; set; }
    }
}
