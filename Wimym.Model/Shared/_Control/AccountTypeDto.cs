namespace Wimym.Model.Shared._Control
{
    using System.Collections.Generic;
    using Wimym.Model.Shared._General;

    public class AccountTypeDto
    {
        public int AccountTypeId { get; set; }

        public string Code { get; set; }
               
        public string Name { get; set; }
                  
        public string Description { get; set; }

        public bool State { get; set; }
        
       // public  Origin Origin { get; set; }
        public int OriginId { get; set; }

        public List<AccountingAccountDto> AccountingAccounts { get; set; }
    }

    public class AccountTypeGetFilter
    {
        public int? AccountTypeId { get; set; }
    }

    public class AccountTypeListFilter
    {
        public int? AccountTypeId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }
    }

    public class AccountTypeList
    {
        //public int AccountTypeId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool State { get; set; }

        // public  Origin Origin { get; set; }
        public string Origin { get; set; }

        public List<AccountingAccountDto> AccountingAccounts { get; set; }
    }

}
