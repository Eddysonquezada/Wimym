namespace Wimym.Web.Data.Entities
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //using Wimym.Domain.DataEntities.App;

    //credit card, loan, saving account
    public class AccountType
    {       
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        [Display(Name = "Account Type")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        public string Description { get; set; }

        public bool State { get; set; }
               
        public  Origin Origin { get; set; }
       
        public  ICollection<Account> Accounts { get; set; }
    }
}
