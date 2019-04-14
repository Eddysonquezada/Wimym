namespace Wimym.Web.Data.Entities
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    // using Wimym.Domain.DataEntities.Configuration;

    public class Account
    {        
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public bool State { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        public AccountType AccountType { get; set; }

        public Wallet Wallet { get; set; }

        public Currency Currency { get; set; }
                      
    }
}