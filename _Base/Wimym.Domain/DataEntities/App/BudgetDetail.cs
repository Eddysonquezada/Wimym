using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wimym.Domain.DataEntities.Configuration;

namespace Wimym.Domain.DataEntities.App
{
    public class BudgetDetail
    {
        public int BudgetDetailId { get; set; }

        [Display(Name = "Estimated Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Type")]
        public int OriginId { get; set; }

        [Display(Name = "Tag, Label (Concept)")]
        public int TagId { get; set; }

        [Display(Name = "Estimated Amount")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //public decimal PreviousAmount { get; set; }

        [Display(Name = "Is Recurrent?")]
        public bool Recurrent { get; set; }

        public int PeriodicityId { get; set; }

        [MaxLength(500, ErrorMessage = "Max length is {1} characters")]
        public string Observations { get; set; }

        public int StatusId { get; set; }

        public int BudgetId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual Periodicity Periodicity { get; set; }
        [JsonIgnore]
        public virtual Budget Budget { get; set; }
        [JsonIgnore]
        public virtual Origin Origin { get; set; }
        [JsonIgnore]
        public virtual Tag Tag { get; set; }
    }
}
