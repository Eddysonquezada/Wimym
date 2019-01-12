namespace Wimym.Model.Domain._Control
{
    using Model.Domain._General;
    using System.Collections.Generic;

    public class AccountType
    {
       // [Key]
        public int AccountTypeId { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        //[Display(Name = "Account Type")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[MaxLength(100, ErrorMessage = "Max length is {1} characters")]        
        public string Description { get; set; }

        public bool State { get; set; }
        
        public  Origin Origin { get; set; }
        public int OriginId { get; set; }

        public virtual ICollection<AccountingAccount> AccountingAccounts { get; set; }
    }
}
