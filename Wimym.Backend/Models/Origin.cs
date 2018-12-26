namespace Wimym.Backend.Models
{

    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
  //  using Wimym.Domain.DataEntities.App;

    public class Origin
    {
        [Key]
        public int OriginId { get; set; }

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

        [JsonIgnore]
        public virtual ICollection<AccountType> AccountTypes { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
        //[JsonIgnore]
        //public virtual ICollection<Operation> Operations { get; set; }
    }
}
