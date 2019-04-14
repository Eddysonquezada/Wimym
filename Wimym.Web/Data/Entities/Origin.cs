namespace Wimym.Web.Data.Entities
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //  using Wimym.Domain.DataEntities.App;

    //debit, credit
    public class Origin
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(2, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        [Display(Name = "Origin Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30, ErrorMessage = "Max length is {1} characters")]
        public string Description { get; set; }

        public string Simbol { get; set; }

        public ICollection<AccountType> AccountTypes { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Operation> Operations { get; set; }
    }
}
