namespace Wimym.Model.Domain._Control
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class UserType
    {
       // [Key]
        public int UserTypeId { get; set; }

        //[Required(ErrorMessage = "The field {0} is required")]
        //[MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        //[Display(Name = "User Type")]
        public string Name { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
