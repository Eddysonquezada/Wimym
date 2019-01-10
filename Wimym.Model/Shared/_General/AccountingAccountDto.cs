namespace Wimym.Model.Shared._General
{
    using Wimym.Model.Domain._Control;
    using Wimym.Model.Domain.DbHelper;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AccountingAccountDto
    {
        public int AccountingAccountId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool State { get; set; }

        public bool Deleted { get; set; }

        //public  Currency Currency { get; set; }
        public int CurrencyId { get; set; }

        //  public  Wallet Wallet { get; set; }
        public int WalletId { get; set; }

        //  public  AccountType AccountType { get; set; }
        public int AccountTypeId { get; set; }

    }

    public class AccountingAccountGetFilter
    {
        public int? AccountingAccountId { get; set; }
    }
   
    //los parametros mediante los cuales podemos filtrar
    public class AccountingAccountListFilter
    {
        public int? AccountingAccountId { get; set; }

        public string Code { get; set; }

        public int? CurrencyId { get; set; }

        public int? WalletId { get; set; }

        public int? AccountTypeId { get; set; }
    }

    //representacion de las listas
    public class AccountingAccountList
    {
       // public int AccountingAccountId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool State { get; set; }

        // public bool Deleted { get; set; }

        // public  Currency Currency { get; set; }
        //  public int CurrencyId { get; set; }
        public string Currency { get; set; }

        //  public  Wallet Wallet { get; set; }
        //  public int WalletId { get; set; }
        public string Wallet { get; set; }

        //  public  AccountType AccountType { get; set; }
        // public int AccountTypeId { get; set; }
        public string AccountType { get; set; }
    }
}
