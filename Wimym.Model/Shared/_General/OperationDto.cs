namespace Wimym.Model.Shared._General
{
    using Wimym.Model.Domain._Control;
    using Wimym.Model.Domain.DbHelper;
    using System;
    using System.ComponentModel.DataAnnotations;
    using Wimym.Model.Shared._Control;

    public class OperationDto
    {       
        public long OperationId { get; set; }
               
        public DateTime Date { get; set; }  
                   
        public decimal Amount { get; set; } //transaction amount
               
        public bool Recurrent { get; set; }             

        public string Observations { get; set; }

        //public int StatusId { get; set; }
        public bool Deleted { get; set; }

        public   PeriodicityDto Periodicity { get; set; }
        public int PeriodicityId { get; set; }

        public   AccountingAccountDto Account { get; set; }
        public int AccountId { get; set; } //  [Display(Name = "Cuenta")]        
        // public int? AccountId2 { get; set; } //[Display(Name = "Destination (Target)")]
        public AccountingAccountDto AccountDest { get; set; }
        public int AccountDestId { get; set; }

        public   TagDto Tag { get; set; }
        public int TagId { get; set; } // [Display(Name = "Label (Concept)")]

        public   OriginDto Origin { get; set; }
        public int OriginId { get; set; }

        public UserDto User { get; set; }
        public string UserId { get; set; }

    }

    public class OperationGetFilter
    {
        public long? OperationId { get; set; }
    }

    public class OperationListFilter
    {
        public long? OperationId { get; set; }
        
        public int? PeriodicityId { get; set; }

        public int? AccountId { get; set; } //  [Display(Name = "Cuenta")]        
       
        public int? AccountDestId { get; set; }

        public int? TagId { get; set; } // [Display(Name = "Label (Concept)")]

        public int? OriginId { get; set; }

        public string UserId { get; set; }

    }

    public class OperationList  
    {
       // public long OperationId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; } //transaction amount

        public bool Recurrent { get; set; }

        public string Observations { get; set; }

        //public int StatusId { get; set; }
        public bool Deleted { get; set; }
      
        public string Periodicity { get; set; }

        public string Account { get; set; } //  [Display(Name = "Cuenta")]        
  
        public string AccountDest { get; set; }

        public string Tag { get; set; } // [Display(Name = "Label (Concept)")]

        public string Origin { get; set; }

        public string User { get; set; }

    }
}
