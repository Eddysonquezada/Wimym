namespace Wimym.Backend.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Currency
    {
        //just in case than I want to give a distinct name, 
        //than dindt have the Id or ClassNameId, but is a god practice put it anyway
        [Key]
        public int CurrencyId { get; set; }  //and is a good practice name it ClassName + Id

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(3, ErrorMessage = "Max length is {1} characters")]
        [Display(Name = "Currency Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "The {0} must be at least {2}  and less than {1} characters")]
        [Display(Name ="Currency Name")]
        public string Name { get; set; }
    }
}
