namespace Wimym.Model.Shared._Control
{
    using System.Collections.Generic;
    using Wimym.Model.Shared._General;

    public class CurrencyDto
    {        
        public int CurrencyId { get; set; } 
      
        public string Code { get; set; }
      
        public string Name { get; set; }
        
        public List<AccountingAccountDto> AccountingAccounts { get; set; }
    }

    public class CurrencyGetFilter
    {
        public int? CurrencyId { get; set; }
    }

    public class CurrencyListFilter
    {
        public int? CurrencyId { get; set; }

        public string Code { get; set; }
    }

    public class CurrencyListDto
    {
        //public int CurrencyId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public List<AccountingAccountDto> AccountingAccounts { get; set; }
    }
}
