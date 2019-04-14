namespace Wimym.Web.Data.Entities
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    // using Wimym.Domain.DataEntities.App;
    
    public class Currency
    {
        //just in case than I want to give a distinct name, 
        //than dindt have the Id or ClassNameId, but is a god practice put it anyway
        public int Id { get; set; } //and is a good practice name it ClassName + Id

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "The {0} must be at least {2} and less than {1} characters")]
        [Display(Name = "Currency")]
        public string Name { get; set; }

        public bool State { get; set; } = true;

        public ICollection<Account> Accounts { get; set; }
    }
}
