namespace Wimym.Model.Domain._General
{
    using Wimym.Model.Domain._Control;
    using Wimym.Model.Domain.DbHelper;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Operation : AuditEntity, ISoftDeleted
    {
       // [Key]
        public long OperationId { get; set; }
        
       // [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }  
             
       // [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; } //transaction amount

        //[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        //public decimal AccAccountPrevAmount { get; set; } //amount before this transaction

       // [Display(Name = "Is Recurrent?")]
        public bool Recurrent { get; set; }

       // [MaxLength(500, ErrorMessage = "Max length is {1} characters")]

        public string Observations { get; set; }

        //public int StatusId { get; set; }
        public bool Deleted { get; set; }

        public   Periodicity Periodicity { get; set; }
        public int PeriodicityId { get; set; }

        public   AccountingAccount Account { get; set; }
        public int AccountId { get; set; } //  [Display(Name = "Cuenta")]        
        // public int? AccountId2 { get; set; } //[Display(Name = "Destination (Target)")]
        public AccountingAccount AccountDest { get; set; }
        public int AccountDestId { get; set; }

        public   Tag Tag { get; set; }
        public int TagId { get; set; } // [Display(Name = "Label (Concept)")]

        public   Origin Origin { get; set; }
        public int OriginId { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

    }
}
