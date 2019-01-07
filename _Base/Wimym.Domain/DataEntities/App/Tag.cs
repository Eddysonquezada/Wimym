using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wimym.Domain.DataEntities.Configuration;

namespace Wimym.Domain.DataEntities.App
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        [Display(Name = "Tag, Label (Concept)")]
        public string Description { get; set; }
          
        public int StatusId { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //[Display(Name = "Wasted")]
        //public decimal Amount2 { get; set; }

        //public decimal PreviousAmount { get; set; }
              
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
        [JsonIgnore]
        public virtual ICollection<Operation> Operations { get; set; }
        [JsonIgnore]
        public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
    }
}
