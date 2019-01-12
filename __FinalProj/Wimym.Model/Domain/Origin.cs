using System.ComponentModel.DataAnnotations;
using Wimym.Model.Domain.DbHelper;

namespace Wimym.Model.Domain
{
    public class Origin : AuditEntity, ISoftDeleted
    {
        [Key]
        public int OriginId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(2, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(10, ErrorMessage = "Max length is {1} characters")]
        [Display(Name = "Origin Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30, ErrorMessage = "Max length is {1} characters")]
        public string Description { get; set; }

        public string Simbol { get; set; }
          
       // public virtual ICollection<AccountType> AccountTypes { get; set; }

        public bool Deleted { get; set; }
    }
}
