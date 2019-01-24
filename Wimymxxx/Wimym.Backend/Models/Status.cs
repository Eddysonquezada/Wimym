namespace Wimym.Backend.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    //using Wimym.Domain.DataEntities.App;

    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        public string Table { get; set; }

        [JsonIgnore]
        public virtual ICollection<AccountType> AccountTypes { get; set; }


        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
        [JsonIgnore]
        public virtual ICollection<Wallet> Wallets { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Operation> Operations { get; set; }
    }
}
