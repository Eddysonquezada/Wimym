namespace Wimym.Model.Shared._General
{
    using Wimym.Model.Domain._Control;
    using Wimym.Model.Domain.DbHelper;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BudgetDto : AuditEntity, ISoftDeleted
    {
        public int BudgetId { get; set; }

        [Display(Name = "Estimate Amount")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //public decimal PreviousAmount { get; set; }

        [MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        public string Name { get; set; }

        public bool State { get; set; }

        public int UserId { get; set; }

        [JsonIgnore]
        public virtual Status Status { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [JsonIgnore]
        public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }

       

    }
}
