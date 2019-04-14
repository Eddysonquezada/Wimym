using System;
using System.Collections.Generic;
using System.Text;

namespace Wimym.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Wymim.Domain.Helper;

    public class Account : AuditEntity
    {
        [Key]
        public int AccountId { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Account Name")]
        public string Name { get; set; } //it will be an nvarchar (max), and optional

        [MaxLength(100)]
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool State { get; set; }

        //where will be the relation (witch who?) give it a name, its normal 
        //called in the same way than the object
        public Wallet Wallet { get; set; }
        public int WalletId { get; set; }
        //witch will be the referenced field?

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
