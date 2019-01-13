using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Wymim.Domain
{
    public class Account
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
    }
}
