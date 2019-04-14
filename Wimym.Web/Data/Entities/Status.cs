namespace Wimym.Web.Data.Entities
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //using Wimym.Domain.DataEntities.App;

    public class Status
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "The maximun length for field {0} is {1} characters")]
        public string Table { get; set; }

        public ICollection<User> Users { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Wallet> Wallets { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Operation> Operations { get; set; }
    }
}
