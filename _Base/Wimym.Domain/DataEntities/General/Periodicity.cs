using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Wimym.Domain.DataEntities.App;

namespace Wimym.Domain.DataEntities.Configuration
{
    public class Periodicity
    {
        [Key]
        public int PeriodicityId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "La longitud maxima del campo es {1} caracteres")]
        [Display(Name = "Periodicity")]
        public string Name { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<AuthorPlan> AuthorPlans { get; set; }
        [JsonIgnore]
        public virtual ICollection<Account> Accounts { get; set; }

        [JsonIgnore]
        public virtual ICollection<BudgetDetail> BudgetDetails { get; set; }
    }
}
