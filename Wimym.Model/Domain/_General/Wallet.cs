namespace Wimym.Model.Domain._General
{
    using Model.Domain._Control;
    using Model.Domain.DbHelper;
    using System.Collections.Generic;

    public class Wallet : AuditEntity, ISoftDeleted
    {
       // [Key]
        public int WalletId { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[MaxLength(10, ErrorMessage = "Max length is {1} characters")]
         public string Code { get; set; }

        public string Name { get; set; }
        ////[Required(ErrorMessage = "This field is required")]
        ////[MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        ////[Display(Name = "Wallet")]
         public string Description { get; set; }

        //[Display(Name = "Balance")]
        //[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //[Display(Name = "Gastos")]
        //public decimal Amount2 { get; set; }
        //public decimal PreviousAmount { get; set; }

        //[Display(Name = "Usuario")]
        //public int UserId { get; set; }
        public bool State { get; set; }

        public bool Deleted { get; set; }

        public Owner Owner { get; set; }
        public int OwnerId { get; set; }
               
        public  ICollection<AccountingAccount> AccountingAccounts { get; set; }

    }
}
