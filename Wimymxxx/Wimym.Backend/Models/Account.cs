namespace Wimym.Backend.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    // using Wimym.Domain.DataEntities.Configuration;

    public class Account
    {
        [Key]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        public string Description { get; set; }

        [Display(Name = "Estatus")]
        public int StatusId { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        public int AccountTypeId { get; set; }

        public int WalletId { get; set; }

        public int CurrencyId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual Currency Currency { get; set; }
        [JsonIgnore]
        public virtual Wallet Wallet { get; set; }
        [JsonIgnore]
        public virtual AccountType AccountType { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Operation> Operations { get; set; }
    }
}