using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wimym.Domain.DataEntities.Configuration;

namespace Wimym.Domain.DataEntities.App
{
    public class Operation
    {
        public int OperationId { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
          
        public int OriginId { get; set; }

        [Display(Name = "Cuenta")]
        public int AccountId { get; set; }

        [Display(Name = "Destination (Target)")]
        public int? AccountId2 { get; set; }

        [Display(Name = "Label (Concept)")]
        public int TagId { get; set; }
             
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //public decimal PreviousAmount { get; set; }

        [Display(Name = "Is Recurrent?")]
        public bool Recurrent { get; set; }

        public int PeriodicityId { get; set; }

        [MaxLength(500, ErrorMessage = "Max length is {1} characters")]

        public string Observations { get; set; }

        public int StatusId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }
        [JsonIgnore]
        public virtual Periodicity Periodicity { get; set; }
        [JsonIgnore]
        public virtual Account Account { get; set; }
        [JsonIgnore]
        public virtual Tag Tag { get; set; }
        [JsonIgnore]
        public virtual Origin Origin { get; set; }
    }
}
