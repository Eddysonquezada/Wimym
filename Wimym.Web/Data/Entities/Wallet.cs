namespace Wimym.Web.Data.Entities
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Wimym.Web.Data.DbHelper;

    // using Wimym.Domain.DataEntities.Configuration;

    //Personal Money, Bussineess 1, Bussiness 2, Wife Money
    public class Wallet : AuditEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(25, ErrorMessage = "Max length is {1} characters")]
        public string Code { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(100, ErrorMessage = "Max length is {1} characters")]
        [Display(Name = "Wallet")]
        public string Description { get; set; }

        public bool State { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Amount { get; set; }

        //[Display(Name = "Gastos")]
        //public decimal Amount2 { get; set; }
        //public decimal PreviousAmount { get; set; }

       // public Owner Owner { get; set; }

        public ICollection<Account> Accounts { get; set; }

    }
}
