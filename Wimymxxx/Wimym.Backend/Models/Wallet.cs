namespace Wimym.Backend.Models
{

    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
   // using Wimym.Domain.DataEntities.Configuration;

    public class Wallet
    {
        [Key]
        public int WalletId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        [Display(Name = "Wallet")]
        public string Description { get; set; }

        public int StatusId { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //[Display(Name = "Gastos")]
        //public decimal Amount2 { get; set; }
        //public decimal PreviousAmount { get; set; }

        //[Display(Name = "Usuario")]
        //public int UserId { get; set; }
        
        public int OwnerId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }

        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }

    }
}
