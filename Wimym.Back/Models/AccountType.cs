namespace Wimym.Backend.Models
{

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    //using Wimym.Domain.DataEntities.App;

        //credit card, loan, saving account
    public class AccountType
    {
        [Key]
        public int AccountTypeId { get; set; }

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

        public int OriginId { get; set; }
        
        [JsonIgnore]
        public virtual Origin Origin { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
