namespace Wimym.Model.Shared._General
{
    using Wimym.Model.Domain._Control;
    using Wimym.Model.Domain.DbHelper;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TagDto  
    {       
        public int TagId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
                  
        public decimal Amount { get; set; }
              
        public bool State { get; set; }

        public bool Deleted { get; set; }

        public  Owner Owner { get; set; }
        public int OwnerId { get; set; }

        public  List<OperationDto> Operations { get; set; }
       
       // public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
    }

    public class TagGetFilter
    {
        public int? TagId { get; set; }      
    }

    public class TagListFilter 
    {
        public int TagId { get; set; }

        public string Description { get; set; }
               
        public string OwnerId { get; set; }
     
    }

    public class TagList
    {
        // public int TagId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool State { get; set; }

        //public bool Deleted { get; set; }

       // public Owner Owner { get; set; }
        public string Owner { get; set; }

        public List<OperationDto> Operations { get; set; }

        // public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
    }
}
