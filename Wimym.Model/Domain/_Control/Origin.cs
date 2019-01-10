namespace Wimym.Model.Domain._Control
{
    using Model.Domain._General;
    using System.Collections.Generic;

    public class Origin
    {
       // [Key]
        public int OriginId { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[MaxLength(2, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        //[Display(Name = "Origin Name")]
        public string Name { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[MaxLength(30, ErrorMessage = "Max length is {1} characters")]
        public string Description { get; set; }

        public string Simbol { get; set; }
               
        public  ICollection<AccountType> AccountTypes { get; set; }
             
        //public  ICollection<BudgetDetail> BudgetDetails { get; set; }
   
        public  ICollection<Operation> Operations { get; set; }
    }
}
