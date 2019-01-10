namespace Wimym.Model.Shared._Control
{
    using System.Collections.Generic;
    using Wimym.Model.Shared._General;

    public class PeriodicityDto
    {        
        public int PeriodicityId { get; set; }
              
        public string Code { get; set; }
               
        public string Name { get; set; }
     
        public  List<AccountingAccountDto> AccountingAccounts { get; set; }

        //public  List<BudgetDetailDto> BudgetDetails { get; set; }
    }

    public class PeriodicityGetFilter
    {
        public int? PeriodicityId { get; set; }      
    }

    public class PeriodicityListFilter
    {
        public int? PeriodicityId { get; set; }

        public string Code { get; set; }        
    }

    public class PeriodicityList
    {
        //public int PeriodicityId { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public List<AccountingAccountDto> AccountingAccounts { get; set; }

        //public  List<BudgetDetailDto> BudgetDetails { get; set; }
    }
}
