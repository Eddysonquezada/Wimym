namespace Wimym.Model.Domain._General
{
    using Model.Domain._Control;
    using Model.Domain.DbHelper;
    using System.Collections.Generic;

    public class AccountingAccount : AuditEntity, ISoftDeleted
    {
       // [Key]
        public int AccountingAccountId { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        public string Description { get; set; }

        //[Display(Name = "Balance")]
        //[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

       // [Display(Name = "Estatus")]
        public bool State { get; set; }

        public bool Deleted { get; set; }

        public  Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        public  Wallet Wallet { get; set; }
        public int WalletId { get; set; }

        public  AccountType AccountType { get; set; }
        public int AccountTypeId { get; set; }

         public  ICollection<Operation> Operations { get; set; }

        //public ICollection<Operation> Operations { get; set; }

    }
}
