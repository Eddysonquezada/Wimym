namespace Wimym.Model.Domain._General
{
    using Model.Domain._Control;
    using Model.Domain.DbHelper;
    using System.Collections.Generic;

    public class Tag : AuditEntity, ISoftDeleted
    {
       // [Key]
        public int TagId { get; set; }

        public string Name { get; set; }

        //[Required(ErrorMessage = "This field is required")]
        //[MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        //[Display(Name = "Tag, Label (Concept)")]
        public string Description { get; set; }
          
        //[Display(Name = "Balance")]
        //[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //[Display(Name = "Wasted")]
        //public decimal Amount2 { get; set; }

        //public decimal PreviousAmount { get; set; }
        public bool State { get; set; }

        public bool Deleted { get; set; }

        public  Owner Owner { get; set; }
        public int OwnerId { get; set; }

        public  ICollection<Operation> Operations { get; set; }
       
       // public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
    }
}
