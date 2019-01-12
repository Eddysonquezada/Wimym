namespace Wimym.Model.Domain._Control
{
    using Model.Domain._General;
    using System.Collections.Generic;

    public class Periodicity
    {
       // [Key]
        public int PeriodicityId { get; set; }

        //[Required]
        //[MaxLength(15, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string Code { get; set; }

        //[Required]
        //[MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        //[Display(Name = "Periodicity")]
        public string Name { get; set; }

         public ICollection<Operation> Operations { get; set; }

        // public  ICollection<AccountingAccount> AccountingAccounts { get; set; }

        //public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
    }
}
