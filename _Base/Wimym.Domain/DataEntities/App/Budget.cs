using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wimym.Domain.DataEntities.Configuration;

namespace Wimym.Domain.DataEntities.App
{
    public class Budget
    {
        public int BudgetId { get; set; }

        [Display(Name = "Estimate Amount")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //public decimal PreviousAmount { get; set; }

        [MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        public string Name { get; set; }

        public int StatusId { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }

    }
}
