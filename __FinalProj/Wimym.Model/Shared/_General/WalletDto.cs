namespace Wimym.Model.Shared._General
{
    using Model.Domain._Control;
    using System.Collections.Generic;

    public class WalletDto  
    {       
        public int WalletId { get; set; }
               
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
               
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
               
        public virtual List<AccountingAccountDto> AccountingAccounts { get; set; }

    }

    public class WalletGetFilter
    {
        public int? WalletId { get; set; }   
    }

    public class WalletListFilter
    {
        public int? WalletId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }   

    }

    public class WalletList
    {
       // public int WalletId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        //[Display(Name = "Gastos")]
        //public decimal Amount2 { get; set; }
        //public decimal PreviousAmount { get; set; }

        //[Display(Name = "Usuario")]
        //public int UserId { get; set; }
        public bool State { get; set; }

       // public bool Deleted { get; set; }

       // public Owner Owner { get; set; }
        public string Owner{ get; set; }

        public virtual List<AccountingAccountDto> AccountingAccounts { get; set; }

    }
}
